using MachineControl.Camera.Dalsa;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLImg_V2.Data
{
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

        public double Trigger1StartX  =   93.2;
        public double Trigger2StartX  =   93.2;
        public double Trigger4StartX  =   22.1*6+1;

        public double Trigger1StartY  =   125;
        public double Trigger2StartY  =   144;
        public double Trigger4StartY  =   161;

        public double Trigger1EndY    =   95;
        public double Trigger2EndY    =   75;
        public double Trigger4EndY    =   60;

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

            StartXPos = new Dictionary<ScanConfig, double>();
            StartXPos.Add( ScanConfig.Trigger_1, Trigger1StartX );
            StartXPos.Add( ScanConfig.Trigger_2, Trigger2StartX);
            StartXPos.Add( ScanConfig.Trigger_4, Trigger4StartX);

            EndYPos = new Dictionary<ScanConfig , double>();
            EndYPos.Add( ScanConfig.Trigger_1 , Trigger1EndY );
            EndYPos.Add( ScanConfig.Trigger_2 , Trigger2EndY );
            EndYPos.Add( ScanConfig.Trigger_4 , Trigger4EndY );


            RoiList = new Dictionary<ScanConfig, List<Rectangle>>();

            List<Rectangle> Inch2 = new List<Rectangle>();
            Inch2.Add( new Rectangle( 95, 0, 12000, 34000 ) );
            Inch2.Add( new Rectangle( 95, 236, 12000, 34000 ) );
            Inch2.Add( new Rectangle( 95, 478, 12000, 34000 ) );

            List<Rectangle> Inch4 = new List<Rectangle>();
            Inch4.Add( new Rectangle( 95, 0, 12000, 64000 ) );
            Inch4.Add( new Rectangle( 95, 236, 12000, 71000 ) );
            Inch4.Add( new Rectangle( 95, 478, 12000, 71000 ) );
            Inch4.Add( new Rectangle( 95, 478, 12000, 71000 ) );
            Inch4.Add( new Rectangle( 95, 478, 12000, 71000 ) );
            Inch4.Add( new Rectangle( 95, 478, 12000, 71000 ) );


            RoiList.Add( ScanConfig.Trigger_2 , Inch2 );
            RoiList.Add( ScanConfig.Trigger_4 , Inch4 );
           
        }
    }
}
