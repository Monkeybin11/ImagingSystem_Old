using MachineControl.Camera.Dalsa;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLImg_V2.Data
{
	public class TriggerScanData_New
	{
		public double YStart;
		public double YEnd;
		public double[] XstartList;
		public int LineRate;
		public int ScanSpeed;

		public TriggerScanData_New( double[] configlist )
		{
			YStart	= configlist[0];
			YEnd	= configlist[1];
			XstartList = new double[]
			{
				configlist[2],
				configlist[3],
				configlist[4],
				configlist[5],
				configlist[6],
				configlist[7],
				configlist[8]
			};

			LineRate	= (int)configlist[9];
			ScanSpeed	= (int)configlist[10];
		}

		public TriggerScanData_New()
		{
			YStart = 150;
			YEnd = 78;
			XstartList = new double[]
			{
				22.1, 44.2, 66.3, 88.4, 110.5, 132.6
			};
			LineRate = 4280;
			ScanSpeed = 8;
		}
	}



	public class TriggerScanData
    {
        public Dictionary<ScanConfig,double> StartYPos;
        public Dictionary<ScanConfig,double> StartXPos;
        public Dictionary<ScanConfig,double> EndYPos;

        public Dictionary<ScanConfig,List<Rectangle>> RoiList;

        public double XStep_Size       = 22.1;
        public double Scan_Stage_Speed = 3;
        public double Camera_Exposure  = 800;
        public double Camera_LineRate  = 1240;

        public double Trigger1StartX  =   92.3;
        public double Trigger2StartX  =   95.2;//93.2
        public double Trigger4StartX  =   22.1*5+5;
        public double Trigger6StartX  =   157;//22.1*7+5;

        public double Trigger1StartY  =   125;//125;
        public double Trigger2StartY  =   150;//145;
        public double Trigger4StartY  =   175;//163;
        public double Trigger6StartY  =   189.5;//163;

        public double Trigger1EndY    =   90;
        public double Trigger2EndY    =   78;
        public double Trigger4EndY    =   60;
        public double Trigger6EndY    =   34;

        public TriggerScanData() { UpdateScanLocation(); }
        //public TriggerScanData(
        //    double startYPos        = 49 ,
        //    double startXPos        = 49 ,
        //    double xStep_Size       = 22.6 ,
        //    double scan_Stage_Speed = 3,
        //    double camera_Exposure  = 2400,
        //    double camera_LineRate  = 400
        //    )
        //{
        //    XStep_Size       = xStep_Size ;
        //    Scan_Stage_Speed = scan_Stage_Speed;
        //    Camera_Exposure  = camera_Exposure;
        //    Camera_LineRate  = camera_LineRate;
        //
        //    CreateEndPoint();
        //}

        public void UpdateScanLocation() {
            StartYPos = new Dictionary<ScanConfig, double>();
            StartYPos.Add( ScanConfig.Trigger_1, Trigger1StartY );
            StartYPos.Add( ScanConfig.Trigger_2, Trigger2StartY );
            StartYPos.Add( ScanConfig.Trigger_4, Trigger4StartY );
            StartYPos.Add( ScanConfig.Trigger_6, Trigger6StartY );

            StartXPos = new Dictionary<ScanConfig, double>();
            StartXPos.Add( ScanConfig.Trigger_1, Trigger1StartX );
            StartXPos.Add( ScanConfig.Trigger_2, Trigger2StartX);
            StartXPos.Add( ScanConfig.Trigger_4, Trigger4StartX);
            StartXPos.Add( ScanConfig.Trigger_6, Trigger6StartX);

            EndYPos = new Dictionary<ScanConfig , double>();
            EndYPos.Add( ScanConfig.Trigger_1 , Trigger1EndY );
            EndYPos.Add( ScanConfig.Trigger_2 , Trigger2EndY );
            EndYPos.Add( ScanConfig.Trigger_4 , Trigger4EndY );
            EndYPos.Add( ScanConfig.Trigger_6 , Trigger6EndY );


            RoiList = new Dictionary<ScanConfig, List<Rectangle>>();


            List<Rectangle> Inch1 = new List<Rectangle>();
            Inch1.Add( new Rectangle( 500, 500, 11000, 10800 ) );

            List<Rectangle> Inch2 = new List<Rectangle>();
            Inch2.Add( new Rectangle( 95, 0  , 12000, 34000 ) );
            Inch2.Add( new Rectangle( 95, 236, 12000, 34000 ) );
            Inch2.Add( new Rectangle( 95, 478, 12000, 34000 ) );

            List<Rectangle> Inch4 = new List<Rectangle>();
            Inch4.Add( new Rectangle(95, 0  , 11905, 59000 ) );
            Inch4.Add( new Rectangle(95, 236, 11905, 59000 ) );
            Inch4.Add( new Rectangle(95, 478, 11905, 59000 ) );
            Inch4.Add( new Rectangle(95, 478, 11905, 59000 ) );
            Inch4.Add( new Rectangle(95, 478, 11905, 59000 ) );

            List<Rectangle> Inch6 = new List<Rectangle>();
            Inch6.Add( new Rectangle( 0, 0, 82000, 82000 ) );
            Inch6.Add( new Rectangle( 0, 0, 82000, 82000 ) );
            Inch6.Add( new Rectangle( 0, 0, 82000, 82000 ) );
            Inch6.Add( new Rectangle( 0, 0, 82000, 82000 ) );
            Inch6.Add( new Rectangle( 0, 0, 82000, 82000 ) );
            Inch6.Add( new Rectangle( 0, 0, 82000, 82000 ) );
            Inch6.Add( new Rectangle( 0, 0, 82000, 82000 ) );
            Inch6.Add( new Rectangle( 0, 0, 82000, 82000 ) );
            Inch6.Add( new Rectangle( 0, 0, 82000, 82000 ) );



            RoiList.Add( ScanConfig.Trigger_1 , Inch1 );
            RoiList.Add( ScanConfig.Trigger_2 , Inch2 );
            RoiList.Add( ScanConfig.Trigger_4 , Inch4 );
            RoiList.Add( ScanConfig.Trigger_6 , Inch6 );
           
        }
    }
}
