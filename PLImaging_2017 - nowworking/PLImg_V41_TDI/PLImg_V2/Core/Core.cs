﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MachineControl.Camera.Dalsa;
using MachineControl.Stage.ACSController;
using DALSA.SaperaLT.SapClassBasic;
using Emgu.CV;
using Emgu.CV.Structure;
using Accord.Math;
using MachineControl.MathClac;
using PLImg_V2.Data;
using EmguCvExtension;
using ChipProcessingLib;
using System.IO.Ports;
using System.Threading;
using System.Drawing;

namespace PLImg_V2
{
    public partial class Core
    {
        public object key = new object();

        #region Event
        public event TferImgArr        evtRealimg   ;
        public event TferTrgImgArr     evtTrgImg    ;
        public event TferTrgImgArr     evtScterImg    ;
        public event TferImgArr     evtAreaImg    ;
        public event TferImgArr     evtAlignImg    ;

        public event TferFeedBackPos   evtFedBckPos ;
        public event TferScanStatus    evtScanEnd   ;
        public event TferNumber        evtSV        ;

        public event Action<Image<Bgr,byte>,bool>     evtTrgIdxImg;
        #endregion  


        public ProcessingCore ChipProcCore;// = new ProcessingCore();
        public IConfig ProcConfig;

        public DalsaPiranha3_12k Cam = new DalsaPiranha3_12k();
        public AcsCtrlXYZ Stg        = new AcsCtrlXYZ();
        public ScanInfo Info         = new ScanInfo();
		//public TriggerScanData TrigScanData = new TriggerScanData();
		public TriggerScanData_New TrigScanData;
        Indicator Idc = new Indicator();


        /*GFunc*/
        public Dictionary<ScanConfig , Action> Reconnector = new Dictionary<ScanConfig, Action>();
        public Dictionary<ScanConfig , Action> ExposureMode = new Dictionary<ScanConfig, Action>();
        public Dictionary<string,Action> StgEnable;

        public Action Connect_XYZStage;
        public Action<double> LineRate;
        public Action<double> Exposure;
        public Action         Exposure_NonTrgMode;
        public Action         Exposure_TrgMode;
        public Action         Grab;
        public Action         Freeze;
        public Action         BufClear;

        public Func<SapBuffer,byte[]>   FullBuffdata;
        public Func<SapBuffer,byte[]>   SingleBuffdata;
        public Func<byte[], int, Image<Gray, byte>> Reshape2D;

        public bool IsArea = false;
        public bool FlgIsScatter = false;
        public bool FlgRemoveBack = false;

        public int PLBias = 60;
        public int SCBias = 60;
        public List<Image<Gray,byte>> ScanedPLImage;
        public List<Image<Gray,byte>> ScanedSCImage;


        #region Init
        public Core()
        {
            ScanedPLImage = new List<Image<Gray, byte>>();
        }

        public Action<ScanConfig> ConnectDevice( string camPath, string stgPath, string rstagPath )
        {
            Create_Connector( camPath, stgPath, rstagPath );
            return new Action<ScanConfig>( ( config ) =>
            {
                ChipProcCore = new ProcessingCore();
                Reconnector[config]();
                ExposureMode[config]();
                Connect_XYZStage();
                InitFunc();
                InitData();
                foreach ( var item in StgEnable ) item.Value();
                Reshape2D = FnBuff2Img( ImgWH["H"], ImgWH["W"] );
                ChipProcCore.evtTrsIdxImage += new Action<Image<Bgr, byte>>( (x => evtTrgIdxImg(x,FlgIsScatter)) );

            } );
        }


        public void Create_Connector( string camPath, string stgPath, string rstagPath )
        {
            //Reconnector.Add( ScanConfig.nonTrigger , Cam.Connect( camPath , ScanConfig.nonTrigger ) );
            Reconnector.Add( ScanConfig.Trigger_1, Cam.Connect( camPath, ScanConfig.Trigger_1 ) );
            Reconnector.Add( ScanConfig.Trigger_2, Cam.Connect( camPath, ScanConfig.Trigger_2 ) );
            Reconnector.Add( ScanConfig.Trigger_4, Cam.Connect( camPath, ScanConfig.Trigger_4 ) );
            Reconnector.Add( ScanConfig.Trigger_6, Cam.Connect( camPath, ScanConfig.Trigger_6 ) );
            Reconnector.Add( ScanConfig.Area, Cam.Connect( camPath, ScanConfig.Area ) );
            Reconnector.Add( ScanConfig.Align, Cam.Connect( camPath, ScanConfig.Area ) );

            //ExposureMode.Add( ScanConfig.nonTrigger, Cam.ExposureMode( 7 ) );
            ExposureMode.Add( ScanConfig.Trigger_1, Cam.ExposureMode( 3 ) );
            ExposureMode.Add( ScanConfig.Trigger_2, Cam.ExposureMode( 3 ) );
            ExposureMode.Add( ScanConfig.Trigger_4, Cam.ExposureMode( 3 ) );
            ExposureMode.Add( ScanConfig.Trigger_6, Cam.ExposureMode( 3 ) );
            ExposureMode.Add( ScanConfig.Area, Cam.ExposureMode( 3 ) );
            ExposureMode.Add( ScanConfig.Align, Cam.ExposureMode( 3 ) );


            var stgConnectMode = MachineControl.Stage.Interface.ConnectMode.IP;
            Connect_XYZStage = Stg.Connect( stgPath, stgConnectMode );
        }


        public void InitFunc()
        {
            Cam.EvtResist( Cam.Xfer, GrabDoneEvt_Non );
            Exposure = Cam.Exposure();
            LineRate = Cam.LineRate();
            Exposure_NonTrgMode = Cam.ExposureMode( 2 );
            Exposure_TrgMode = Cam.ExposureMode( 6 );


            Grab = Cam.Grab();
            Freeze = Cam.Freeze();
            BufClear = Cam.BuffClear();
            FullBuffdata = Cam.BuffGetAll();
            SingleBuffdata = Cam.BuffGetLine();

            StgEnable = new Dictionary<string, Action>();
            foreach ( var item in GD.YXZ ) StgEnable.Add( item, Stg.Enable( item ) );

            //RunStgBuffer = new Action<ScanConfig>( ( config ) =>
            //{
            //    if ( config == ScanConfig.Trigger_1 )
            //    {
            //        Stg.StartTrigger( 3 );
            //    }
            //    else if ( config == ScanConfig.Trigger_2 )
            //    {
            //        Stg.StartTrigger( 4 );
            //    }
            //    else if( config == ScanConfig.Trigger_4)
            //    {
            //        Stg.StartTrigger( 5 );
            //    }
            //    else if ( config == ScanConfig.Trigger_6 )
            //    {
            //        Stg.StartTrigger( 6 );
            //    }
            //} );

            RunStgBuffer = new Action<ScanConfig>( ( config ) =>
            {
                if ( config == ScanConfig.Trigger_1 )
                {
                    Stg.StartTrigger( 3 );
                }
                else if ( config == ScanConfig.Trigger_2 )
                {
                    Stg.StartTrigger( 3 );
                }
                else if ( config == ScanConfig.Trigger_4 )
                {
                    Stg.StartTrigger( 3 );
                }
                else if ( config == ScanConfig.Trigger_6 )
                {
                    Stg.StartTrigger( 3 );
                }
            } );


            //StopStgBuffer = new Action<ScanConfig>( ( config ) =>
            //{
            //    if ( config == ScanConfig.Trigger_1 )
            //    {
            //        Stg.StopTrigger( 3 );
            //    }
            //    else if ( config == ScanConfig.Trigger_2 )
            //    {
            //        Stg.StopTrigger( 4 );
            //    }
            //    else if ( config == ScanConfig.Trigger_4 )
            //    {
            //        Stg.StopTrigger( 5 );
            //    }
            //    else if ( config == ScanConfig.Trigger_6 )
            //    {
            //        Stg.StopTrigger( 6 );
            //    }
            //} );

            StopStgBuffer = new Action<ScanConfig>( ( config ) =>
            {
                if ( config == ScanConfig.Trigger_1 )
                {
                    Stg.StopTrigger( 3 );
                }
                else if ( config == ScanConfig.Trigger_2 )
                {
                    Stg.StopTrigger( 3 );
                }
                else if ( config == ScanConfig.Trigger_4 )
                {
                    Stg.StopTrigger( 3 );
                }
                else if ( config == ScanConfig.Trigger_6 )
                {
                    Stg.StopTrigger( 3 );
                }
            } );
        }

        public void InitData()
        {
            ImgWH = Cam.GetBuffWH();
            
            ProcConfig = new Config()
            {
                ChipWNum = 400,
                ChipHNum = 400,
                ChipWSize = 24,
                ChipHSize = 24,
                ThrsUpLimt = 0,
                ThrsDwLimt = 0,
                AreaUpLimt = 500,
                AreaDwLimt = 500,
                TLX = 0,
                TLY = 0,
                TRX = 0,
                TRY = 0,
                BLX = 0,
                BLY = 0,
                BRX = 0,
                BRY = 0
            };
        }

        #endregion

        #region GrabDoneEvent Method

        int CurrentLinerate = 0;

        void GrabDoneEvt_Non( object sender, SapXferNotifyEventArgs evt )
        {
            evtRealimg( Reshape2D( FullBuffdata( Cam.Buffers ), 1 ) );
            Task.Run( () => TferVariance( SingleBuffdata( Cam.Buffers ) ) );
        }
        void GrabDoneEvt_Area( object sender, SapXferNotifyEventArgs evt )
        {
            var Buf2Img = FnBuff2Img( Cam.GetBuffWH()["H"] , Cam.GetBuffWH()["W"] );
            var currentbuff = FullBuffdata(Cam.Buffers);
            var temp = Buf2Img( currentbuff , 1 );
            evtAreaImg( temp );
        }

        void GrabDoneEvt_Align( object sender, SapXferNotifyEventArgs evt )
        {
            var Buf2Img = FnBuff2Img( Cam.GetBuffWH()["H"] , Cam.GetBuffWH()["W"] );
            var currentbuff = FullBuffdata(Cam.Buffers);
            var temp = Buf2Img( currentbuff , 1 );
            evtAlignImg( temp );
        }

        void GrabDoneEvt_Trg( object sender, SapXferNotifyEventArgs evt )
        {
            try
            {
                "Get Image now".Print();
           
                Thread.Sleep( 300 );
                // Extract Final Image
                var count = TrigCount;
                Task.Run( () =>
                {
                    var Buf2Img = FnBuff2Img( Cam.GetBuffWH()["H"] , Cam.GetBuffWH()["W"] );
                    var currentbuff = FullBuffdata(Cam.Buffers);

                    var temp = Buf2Img( currentbuff , 1 )
                                    .Map( x => FlgIsScatter ? x.Normalize((byte)SCBias) : x.Normalize((byte)PLBias));

                    if ( FlgRemoveBack )
                    {
                        var grad = temp.Clone()
									.Median(131)
									.Median(131)
									.Median(131)
									.Median(131)
									.Not();
                        temp = temp * 0.5 + grad * 0.5;
                    }

                    if ( FlgIsScatter )
                    {
                        evtScterImg( temp, count );
                        ProcConfig = ScterConfig.GetInstance();
                    }
                    else
                    {
                        evtTrgImg( temp, count );
                        ProcConfig = PLConfig.GetInstance();
                    }
                    evtScanEnd();
                    //Task.Run( () => ChipProcCore.ProcRun2( temp, x => x, ProcConfig ) );
                } );
                // Get Index Image from event 
                // 1 Trigger = 1 Buffer
                lock ( key )
                {
                    Console.WriteLine( "Trigcount is updated to {0}", TrigCount . ToString() );
                    if ( TrigCount < TrigLimit - 1 )
                    {
                        TrigCount += 1;
                        //"Move Next Position".Print();
                        //StopStgBuffer( CurrentConfig );
                        //System.Threading.Thread.Sleep( 1000 );
                        StgReadyTrigScan( TrigCount, CurrentConfig );
                        System.Threading.Thread.Sleep( 100 );
                        RunStgBuffer( CurrentConfig );
                        System.Threading.Thread.Sleep( 100 );
                        ScanMoveXYstg( "Y", TrigScanData.YEnd, TrigScanData.ScanSpeed );
                        System.Threading.Thread.Sleep( 16000 / TrigScanData.ScanSpeed );
                        StopStgBuffer( CurrentConfig );
						Stg.WaitEps( "Y" )( TrigScanData.YEnd, 0.1 );
                       
                        //StopStgBuffer( CurrentConfig );
                    }
                    else
                    {
                        StopStgBuffer( CurrentConfig );
                        Console.WriteLine( "Scan is Done. Will start next scan" );
                        
                    }
               }
            }
            catch ( Exception ex )
            {
                Console.WriteLine( ex.ToString() );
                evtScanEnd();
            }


        }
        #endregion

        public void TferVariance( byte[] src )
        {
            try
            {
                double[] dst = new double[src.Length];
                Array.Copy( src, dst, src.Length );
                var zscore = Idc.Zscore( dst );
                var vari = Idc.Variance(zscore());
                Task.Run( () => evtSV( vari() ) );
            }
            catch ( Exception ex )
            {
                Console.WriteLine( ex.ToString() );
            }

        }

        #region Stage Control
        public void MoveXYstg( string axis, double point )
        {
            Stg.SetSpeed( axis )( 200 );
            Stg.Moveabs( axis )( point );
        }

        public void ScanMoveXYstg( string axis, double point, double scanspeed )
        {
            Stg.SetSpeed( axis )( scanspeed );
            Stg.Moveabs( axis )( point );
        }


        public void MoveZstg( double point )
        {
            Stg.SetSpeed( "Z" )( 10 );
            Stg.Moveabs( "Z" )( point );
        }
        public void GetFeedbackPos()
        {
            try
            {
                while ( true )
                {
                    var yP = Stg.GetPos("Y");
                    var xP = Stg.GetPos("X");
                    var zP = Stg.GetPos("Z");
                    evtFedBckPos( new double[3] { yP(), xP(), zP() } );
                    Task.Delay( 500 ).Wait();
                }
            }
            catch ( Exception ex )
            {
                Console.WriteLine( ex.ToString() );
            }
        }
        #endregion

        #region Minor

        void LoadSetting()
        {

        }
        void SaveSetting()
        {

        }
        void SetDir()
        {
            //string dirTempPath = String.Format(ImgBasePath + DateTime.Now.ToString("MM/dd/HH/mm/ss"));
            //CheckAndCreateFolder cacf = new CheckAndCreateFolder(dirTempPath);
            //cacf.SettingFolder( dirTempPath );
            //GrabM.SetDirPath( dirTempPath );
        }

        #endregion


    }
}
