using Emgu.CV;
using Emgu.CV.Structure;
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
using System.Windows.Shapes;
using EmguCvExtension;

namespace PLImg_V2
{
    /// <summary>
    /// Interaction logic for Align.xaml
    /// </summary>
    public partial class Align : Window
    {
        public event Action evtClosing;
        public event Action evtStart;
        public event Action evtZOrigin;
        public event Action evtView;
        //public event Action evtDisplayDone;
        public event Action<double> evtUpZ;
        public event Action<double> evtDwZ;
        public event Action<double> evtUpY;
        public event Action<double> evtDwY;

        Core_RStage RCore = new Core_RStage();
        Image<Gray,byte> CurrentImage;
        double CurrentAngle = 0;

        public Align()
        {
            InitializeComponent();
        }


        private void btnStart_Click( object sender, RoutedEventArgs e )
        {
            evtStart();
            ApplyLine( CurrentImage );
            //RCore.UpdatePos();
        }

        async void ApplyLine(Image<Gray,byte> srcimg)
        {
            CurrentImage = srcimg;
            var workimg = new Image<Gray,byte>(CurrentImage.Data);

           var nudThresval =  (int)nudThres.Value;
            var nudCannyThresval = (int)nudCannyThres.Value;
            var nudCannyLikingval = (int)nudCannyLiking.Value;
            var nudHoughThresval = (int)nudHoughThres.Value;
            var nudLineWidthval = (int)nudLineWidth.Value;
            var nudGapval = (int)nudGap.Value;

            var tsk = Task.Run< Tuple<LineSegment2D,int>>( () =>
            {
                var res = workimg.Median(25);
                var res1 = res                     .Gamma( 8 );
                var res2 = res1                     .Normalize( 40 );
                var res3 = res2                     .ThresholdBinary( new Gray( nudThresval ), new Gray( 255 ) );
                var res4 = res3                     .Sobel( 0, 1, 5 );
                var res5 = res4                     .ThresholdBinary( new Gray( 120 ), new Gray( 255 ) );

                var data = res5.Convert<Bgr,byte>().HoughLines(
                    nudCannyThresval ,
                    nudCannyLikingval,
                    1 ,
                    Math.PI / 1440.0 ,
                    nudHoughThresval,
                    nudLineWidthval,
                    nudGapval);
                //CurrentImage.Save( @"E:\al.png" );
                var datas = data.Flatten();
                if ( data.First().Length <= 0 ) return Tuple.Create(new LineSegment2D() , 0);
                return Tuple.Create( datas.Aggregate( ( f , s ) =>
            {
                var p1 = new System.Drawing.Point
                (
                    f.P1.X + s.P1.X,
                    f.P1.Y + s.P1.Y
                );

                var p2 = new System.Drawing.Point
                (
                    f.P2.X + s.P2.X,
                    f.P2.Y + s.P2.Y
                );
                return new LineSegment2D(p1,p2);
            } ),datas.Length);

            } );


            var result = tsk.Result.Item1;
            var lineCounter = tsk.Result.Item2 == 0 ? 1 : tsk.Result.Item2;

            var img = new Image<Gray,byte>(CurrentImage.Data).Convert<Bgr,byte>();
                LineSegment2D avgLine = new LineSegment2D();


                avgLine = new LineSegment2D(
                                              new System.Drawing.Point
                                                  (
                                                  result.P1.X / lineCounter,
                                                  result.P1.Y / lineCounter
                                                  ),
                                               new System.Drawing.Point
                                                  (
                                                  result.P2.X / lineCounter,
                                                  result.P2.Y / lineCounter
                                                  ) );


                img.Draw( avgLine, new Bgr( 100, 200, 0 ), 2 );

                var xlen = Math.Abs( result.Direction.X ); // Normalized X
                var ylen = Math.Abs( result.Direction.Y );
                var angless = xlen <= 0 ? 0 : Math.Atan(ylen / xlen) * 180 / Math.PI; // degree


            imgboxArea.Image = img;
            lblAngle.Content = angless;
            CurrentAngle = angless; 
        }


        private void btnUp_Click( object sender, RoutedEventArgs e )
        {
            evtUpZ( (double)nudmove.Value );
        }

        private void btnDw_Click( object sender, RoutedEventArgs e )
        {
            evtDwZ( (double)nudmove.Value  );
        }

        private void Window_Closing( object sender, System.ComponentModel.CancelEventArgs e )
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
            evtClosing();
        }

        public void UpdateImg( Image<Gray, byte> img )
        {
            CurrentImage = img;
            imgboxArea.Image = img;
            
            //evtDisplayDone();
        }

        private void btnView_Click( object sender, RoutedEventArgs e )
        {
            evtView();
        }

        private void btnROrigin_Click( object sender, RoutedEventArgs e )
        {
            RCore.Origin();
        }

        private void btnZOrigin_Click( object sender, RoutedEventArgs e )
        {
            evtZOrigin();
        }

        private void btnAlign_Click( object sender, RoutedEventArgs e )
        {
            RCore.UpdatePos( -CurrentAngle );
        }

        private void btnUpY_Click( object sender, RoutedEventArgs e )
        {
            evtUpY( (double)nudmoveY.Value );
        }

        private void btnDwY_Click( object sender, RoutedEventArgs e )
        {
            evtDwY( (double)nudmoveY.Value );
        }
    }
}
