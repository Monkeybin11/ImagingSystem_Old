using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.UI;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using DALSA.SaperaLT.SapClassBasic;
using DALSA.SaperaLT;
using Accord.Math;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using MachineControl.Camera.Dalsa;
using System.Threading;
using WaferandChipProcessing;
using System.Windows.Forms.Integration;
using static PLImg_V2.ImgProcessingLib;

namespace PLImg_V2
{
    enum StageEnableState {
        Enabled,
        Disabled
        
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        Core Core = new Core();
       
        Win_AreaView WinArea = new Win_AreaView();
        Align WinAlign = new Align();
        public SeriesCollection seriesbox { get; set; }
        public ChartValues<int> chartV { get; set; }
        Image[] TrgImgBoxArr;
        Image[] TrgScterImgBoxArr;
        Dictionary<ScanConfig, System.Windows.Controls.RadioButton> SampleConfig;
        Dictionary<string,StageEnableState> StgState;

        List<Image<Gray,byte>> PLImageList;
        List<Image<Gray,byte>> SCImageList;

        public MainWindow()
        {
            InitializeComponent();
            InitImgBox();
            InitLocalData();
            DataContext = this;
            var cd = new ConnectionData();
            Core.ConnectDevice( cd.CameraPath, cd.ControllerIP, cd.RStage )( ScanConfig.Trigger_1 );
            InitCore();
            ckbZDisa_Checked( null, null );
            ckbZDisa.IsChecked = true;

            WinArea.evtClosing += new Action( () => { Core.Freeze(); WinArea.Visibility = Visibility.Hidden;  } );
            WinAlign.evtClosing += new Action( () => { Core.Freeze(); WinAlign.Visibility = Visibility.Hidden; } );

            
            WinAlign.evtStart += new Action(() =>Core.Freeze());
            WinAlign.evtView += new Action(() => Core.StartAlignScan());
            WinAlign.evtUpZ += new Action<double>( pos => Core.Stg.Moverel( "Z")( (pos * -1) ) );
            WinAlign.evtDwZ += new Action<double>( pos => Core.Stg.Moverel("Z")(pos) );
            WinAlign.evtUpY += new Action<double>( pos => Core.Stg.Moverel( "Y" )( pos ) );
            WinAlign.evtDwY += new Action<double>( pos => Core.Stg.Moverel( "Y" )( (pos * -1) ) );
            WinAlign.evtZOrigin += new Action( () => Core.Stg.Home( "Z" )() );

            ucComunication.evtOpenAreaView += new Action( () => { Core.StartAreaScan(); WinArea.Visibility = Visibility.Visible; }  );
            ucComunication.evtOpenAlignView += new Action( () => { Core.StartAlignScan(); WinAlign.Visibility = Visibility.Visible; }  );
            PLImageList = new List<Image<Gray, byte>>();
            SCImageList = new List<Image<Gray, byte>>();
        }


        #region Display
        int temp = 0;
        void DisplayTrgImg( Image<Gray , byte> img , int lineNum )
        {
            temp.Print( "Display Counter is " );
            temp++;
            PLImageList.Add( img );
            var reimg = img.Resize( 0.1, Inter.Nearest );
            this.BeginInvoke( () => TrgImgBoxArr[lineNum].Source = reimg.ToBitmapSource() );
            // ADD vf Value
        }

        void DisplayTrgScterImg( Image<Gray, byte> img, int lineNum )
        {
            SCImageList.Add( img );
            var reimg = img.Resize( 0.1, Inter.Nearest );
            this.BeginInvoke( () => TrgScterImgBoxArr[lineNum].Source = reimg.ToBitmapSource() );
        }
       
      
        void DisplayBuffNumber(int num)
        {
            
            lblBuffNum.BeginInvoke(() => lblBuffNum.Content = num.ToString());
        }


        void DisplayPos( double[] inputPos )
        {
            Task.Run( () => lblXpos.BeginInvoke( (Action)(() => lblXpos.Content = inputPos[0].ToString( "N4" )) ) );
            Task.Run( () => lblYpos.BeginInvoke( (Action)(() => lblYpos.Content = inputPos[1].ToString( "N4" )) ) );
            Task.Run( () => lblZpos.BeginInvoke( (Action)(() => lblZpos.Content = inputPos[2].ToString( "N4" )) ) );
        }

        void DisplayArea( Image<Gray, byte> img )
        {
            this.BeginInvoke((Action)(()=> WinArea.UpdateImg( img) ));
        }

        void DisplayAlign( Image<Gray, byte> img )
        {
            this.BeginInvoke( (Action)(() => WinAlign.UpdateImg( img )) );
           
        }


        void DisplayIdx( Image<Bgr, byte> img, bool flgIsScatter )
        {
            if ( flgIsScatter )
            {
                //string path = @"C:\gangImg\SC.png";
                //
                //
                //imgscterboxOri.BeginInvoke( (Action)(() => imgscterboxOri.Image = new Image<Bgr, byte>( path )) );
            }

            else
            {
                //string path = @"C:\gangImg\PL.png";
                //imgboxOri.BeginInvoke( (Action)(() => imgboxOri.Image = new Image<Bgr,byte>(path)) );

            }


        }

        void DisplayIdx_Backup( Image<Bgr, byte> img , bool flgIsScatter)
        {
            if(flgIsScatter ) imgscterboxOri.BeginInvoke( (Action)(() => imgscterboxOri.Image = img) );
            else imgboxOri.BeginInvoke( (Action)(() => imgboxOri.Image = img) );

           
        }


        #endregion

        #region main
        private void btnStartFixAreaScan_Click( object sender, RoutedEventArgs e )
        {
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

            PLImageList = new List<Image<Gray, byte>>();
            SCImageList = new List<Image<Gray, byte>>();


            ucComunication.SetLine();
            ucComunication.SetLineRate( (int)nudlinerate.Value );
            if ( (bool)ckbScatter.IsChecked ) Core.FlgIsScatter = true;
            else Core.FlgIsScatter = false;

            if ( (bool)ckbBackGoundRemove.IsChecked ) Core.FlgRemoveBack = true;
            else Core.FlgRemoveBack = false;

            Core.PLBias = (int)nudPLBias.Value;
            Core.SCBias = (int)nudScBias.Value;
            Core.ScanedPLImage = new List<Image<Gray, byte>>();

            foreach ( var item in SampleConfig )
            {
                if ( item.Value.IsChecked == true )
                {
                    ResizeTriggerImgBox( item.Key );
					Core.TrigScanData = ucScanconfig.GetConfigs().ToScanData();
                    Core.StartTrigScan( item.Key );
                }
            }
        }

        void ResizeTriggerImgBox( ScanConfig config )
        {
            switch ( config )
            {
                case ScanConfig.Trigger_1:
                    double w1  = dpnlImgResult.ActualWidth-1;
                    double h1 = dpnlImgResult.ActualHeight-1;
                    SetImagesSize( 1, w1, h1 );
                    break;
                     
                case ScanConfig.Trigger_2:
                    double w2 =  ( dpnlImgResult.ActualWidth / 3.0);
                    double h2 = dpnlImgResult.ActualHeight;
                    SetImagesSize( 3, w2, h2 );
                    break;

                case ScanConfig.Trigger_4:
                    double w4 =  ( dpnlImgResult.ActualWidth / 5.0);
                    double h4 = dpnlImgResult.ActualHeight;
                    SetImagesSize( 5, w4, h4 );
                    break;

                case ScanConfig.Trigger_6:
                    double w6 =  ( dpnlImgResult.ActualWidth / 8.0);
                    double h6 = dpnlImgResult.ActualHeight;
                    SetImagesSize( 8, w6, h6 );
                    break;

            }
        }

        void SetImagesSize(int visibleCount , double w , double h)
        {
            for ( int i = 0; i < visibleCount; i++ )
            {
                TrgImgBoxArr[i].Width = w;
                TrgImgBoxArr[i].Height = h;
                TrgScterImgBoxArr[i].Width = w;
                TrgScterImgBoxArr[i].Height = h;
            }

            for ( int i = visibleCount; i < TrgScterImgBoxArr.Length; i++ )
            {
                TrgImgBoxArr[i].Width = 0;
                TrgImgBoxArr[i].Height = h;
                TrgScterImgBoxArr[i].Width = 0;
                TrgScterImgBoxArr[i].Height = h;
            }

        }


        private void btnSaveImg_Click( object sender, RoutedEventArgs e )
        {
            try
            {

                string savePath = "";
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.SelectedPath = @"E:\00PLAY";
               
                if ( fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK )
                {
                    savePath = fbd.SelectedPath;
                    for ( int i = 0; i < PLImageList.Count; i++ )
                    {
                        string filename = savePath + "\\PL_" + i.ToString("D3") + ".png";
                        //TrgImgBoxArr[i].Image?.Save( filename );
                        PLImageList[i].Save( filename );

                       //string filename2 = savePath + "\\PL8_" + i.ToString("D3") + ".png";
                       //var i8 =PLImageList[i].Resize( 0.8, Inter.Cubic );
                       //i8.Save( filename2 );

                      


                    }
                    for ( int i = 0; i < SCImageList.Count; i++ )
                    {
                        string filenameScatter = savePath + "\\Scatter_" + i.ToString("D3") + ".png";
                        SCImageList[i].Save( filenameScatter );

                       // string filenameScatter2 = savePath + "\\Scatter8_" + i.ToString("D3") + ".png";
                       // var i8 =SCImageList[i].Resize( 0.8, Inter.Cubic );
                       // i8.Save( filenameScatter2 );



                    }
                   
                    try
                    {
                        if ( PLImageList.Count != 0 )
                        {
                            var resultpl = PLImageList
                        //.Select( x => x.Image as Image<Gray,byte>)
                        .Select( x => x?.Resize(0.1,Inter.Cubic))
                        .Aggregate((f,s) => s == null ? f : f.ConcateHorizontal(s) );
                            resultpl.Save( savePath + "\\FullPL.png" );
                        }
                       
                        if ( SCImageList.Count != 0 )
                        {
                            var resultsc = SCImageList
                        //.Select( x => (x.Source as BitmapImage).ToMat().ToImage<Gray,byte>())
                        .Select( x => x?.Resize(0.1,Inter.Cubic))
                        .Aggregate((f,s) => s == null ? f : f.ConcateHorizontal(s) );
                            resultsc.Save( savePath + "\\FullSC.png" );
                        }

                       
                       


                    }
                    catch ( Exception ex )
                    {
                        Console.WriteLine( ex.ToString() );
                    }


                }

            }
            catch ( Exception )
            {
            }
        }
        #endregion

        #region Init

       
        
        void InitCore( )
        {
            foreach ( var item in GD.YXZ )
            {
                StgState[item] = StageEnableState.Enabled;
            }
            Core.evtTrgImg        += new TferTrgImgArr( DisplayTrgImg );
            Core.evtScterImg        += new TferTrgImgArr( DisplayTrgScterImg );
            Core.evtFedBckPos     += new TferFeedBackPos( DisplayPos );
            Core.evtScanEnd       += new TferScanStatus( ( ) => { this.BeginInvoke( () => Mouse.OverrideCursor = null ); } );
            Core.evtScanEnd       += new TferScanStatus( ( ) => 
            {
              
            } );
           

            Core.evtAreaImg += new TferImgArr( DisplayArea );
            Core.evtTrgIdxImg += new Action<Image<Bgr, byte>,bool>( DisplayIdx );
            Core.evtAlignImg += new TferImgArr( DisplayAlign );

            Task.Run(()=>Core.GetFeedbackPos());
            InitViewWin();
        }

     
        void InitImgBox()
        {
            TrgImgBoxArr = new Image[10];
            TrgImgBoxArr[0] = imgboxTrig0;
            TrgImgBoxArr[1] = imgboxTrig1;
            TrgImgBoxArr[2] = imgboxTrig2;
            TrgImgBoxArr[3] = imgboxTrig3;
            TrgImgBoxArr[4] = imgboxTrig4;
            TrgImgBoxArr[5] = imgboxTrig5;
            TrgImgBoxArr[6] = imgboxTrig6;
            TrgImgBoxArr[7] = imgboxTrig7;
            TrgImgBoxArr[8] = imgboxTrig8;
            TrgImgBoxArr[9] = imgboxTrig9;

            TrgScterImgBoxArr = new Image[10];
            TrgScterImgBoxArr[0] = imgboxScterTrig0;
            TrgScterImgBoxArr[1] = imgboxScterTrig1;
            TrgScterImgBoxArr[2] = imgboxScterTrig2;
            TrgScterImgBoxArr[3] = imgboxScterTrig3;
            TrgScterImgBoxArr[4] = imgboxScterTrig4;
            TrgScterImgBoxArr[5] = imgboxScterTrig5;
            TrgScterImgBoxArr[6] = imgboxScterTrig6;
            TrgScterImgBoxArr[7] = imgboxScterTrig7;
            TrgScterImgBoxArr[8] = imgboxScterTrig8;
            TrgScterImgBoxArr[9] = imgboxScterTrig9;


            foreach ( var item in TrgImgBoxArr )
            {
                item.Stretch = Stretch.Fill;
            }
            foreach ( var item in TrgScterImgBoxArr )
            {
                item.Stretch = Stretch.Fill;
            }
        }

        void InitViewWin( )
        {
            nudlinerate.Value = 17120;
            //nudlinerate.Value = 1070;
            nudScanSpeed.Value = 32;
            //nudScanSpeed.Value = 2;
            nudGoXPos.Value = 100;
            nudGoYPos.Value = 50;
            nudGoZPos.Value = 26.190;
        }

        void InitLocalData() {
            StgState = new Dictionary<string , StageEnableState>();
            StgState.Add("Y", new StageEnableState());
            StgState.Add("X", new StageEnableState());
            StgState.Add("Z", new StageEnableState());

            SampleConfig = new Dictionary<ScanConfig , System.Windows.Controls.RadioButton>();
            SampleConfig.Add( ScanConfig.Trigger_1  ,rdb1inch);
            SampleConfig.Add( ScanConfig.Trigger_2  ,rdb2inch);
            SampleConfig.Add( ScanConfig.Trigger_4  ,rdb4inch);
            SampleConfig.Add( ScanConfig.Trigger_6  ,rdb6inch);
        }


  
        #endregion

        #region MainWindowEvent
        void ScanStart( ) { Mouse.OverrideCursor = Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;}
        void ScanEnd( ) { Mouse.OverrideCursor = null; }

       
        #region Stage
        // common //
        private void btnOrigin_Click( object sender, RoutedEventArgs e ) {

            Core.Stg.Home( "X" )();
            Core.Stg.Home( "Y" )();
            //foreach ( var item in GD.YXZ ) Core.Stg.Home( item )();
        }

        // XYZStage //
        private void btnYMove_Click( object sender, RoutedEventArgs e )
        {
            if ( StgState["Y"] == StageEnableState.Enabled ) Core.MoveXYstg( "Y" , ( double ) nudGoYPos.Value );
        }
        private void btnXMove_Click( object sender, RoutedEventArgs e )
        {
            if ( StgState["X"] == StageEnableState.Enabled ) Core.MoveXYstg( "X" , ( double ) nudGoXPos.Value );
        }
        private void btnZMove_Click( object sender, RoutedEventArgs e )
        {
            if( StgState["Z"] == StageEnableState.Enabled) Core.MoveZstg( ( double ) nudGoZPos.Value );
        }

      

        // R Stage //
        private void btnRMove_Click( object sender, RoutedEventArgs e )
        {
            double pulse = (double)nudGoRPos.Value * 400;
            
        }
        private void btnROrigin_Click( object sender, RoutedEventArgs e )
        {
           
        }
        private void btnRForceStop_Click( object sender, RoutedEventArgs e )
        {
            
        }
        #endregion

        #endregion

        #region Motor Enable / Disable // Done
        private void ckbYDisa_Checked( object sender , RoutedEventArgs e )
        {
            Core.Stg.Disable( "Y" )();
            StgState["Y"] = StageEnableState.Disabled;
        }
        private void ckbXDisa_Checked( object sender, RoutedEventArgs e ) {
            Core.Stg.Disable("X")();
            StgState["X"] = StageEnableState.Disabled;
        }
        private void ckbZDisa_Checked( object sender, RoutedEventArgs e ) {
            Core.Stg.Disable( "Z" )();
            StgState["Z"] = StageEnableState.Disabled;
        }
        private void ckbYDisa_Unchecked( object sender , RoutedEventArgs e )
        {
            Core.Stg.Enable( "Y" )();
            StgState["Y"] = StageEnableState.Enabled;
        }
        private void ckbXDisa_Unchecked( object sender , RoutedEventArgs e )
        {
            Core.Stg.Enable( "X" )();
            StgState["X"] = StageEnableState.Enabled;
        }
        private void ckbZDisa_Unchecked( object sender, RoutedEventArgs e ) {
            Core.Stg.Enable( "Z" )();
            StgState["Z"] = StageEnableState.Enabled;
        }

        
        #endregion

        #region Sscan data Setting 

        private void nudlinerate_KeyUp( object sender, System.Windows.Input.KeyEventArgs e ) {
            if ( e.Key != System.Windows.Input.Key.Enter ) return;
            Core.LineRate( (int)nudlinerate.Value );
        }

        #endregion

        #region window Event 
        private void MetroWindow_Closing( object sender, System.ComponentModel.CancelEventArgs e ) {
            foreach ( var item in GD.YXZ )
            {
                Core.Stg.Disable( item )();
            }
            Core.Stg.Disconnect()();
            Core.Cam.Freeze();
            Core.Cam.Disconnect()();
            Environment.Exit( Environment.ExitCode );
        }

        private void TabItem_Selected( object sender, RoutedEventArgs e )
        {

        }

        private void TabItem_Unselected( object sender, RoutedEventArgs e )
        {

        }
        #endregion

        #region Tab Select Event

        #endregion

        ////////////////////////////////////////////////////////////////////////
  
        private void btnStartCam_Click( object sender, RoutedEventArgs e )
        {
            Core.StartAreaScan();
        }

 

        private void btnStopCam_Click( object sender, RoutedEventArgs e )
        {
            Core.Freeze();
        }



    }
}
