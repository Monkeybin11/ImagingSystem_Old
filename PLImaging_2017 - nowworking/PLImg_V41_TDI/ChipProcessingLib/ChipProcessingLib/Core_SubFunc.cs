using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChipProcessingLib
{
    public partial class ProcessingCore
    {
        Image<Bgr, byte> DrawBox( Image<Bgr, byte> img, List<System.Drawing.Rectangle> rclist )
        {
            Parallel.For( 0, rclist.Count, i =>
            {
                img.Draw( rclist[i], ApOkChipColor, 1 );
            } );
            return img;
        }

        Image<Bgr, byte> DrawCenterPoint( Image<Bgr, byte> img, double[,,] centrPoint )
        {
            for ( int k = 0; k < 100; k++ )
            {
                for ( int i = 0; i < centrPoint.GetLength( 0 ); i++ )
                {
                    for ( int j = 0; j < centrPoint.GetLength( 1 ); j++ )
                    {
                        CircleF cirp = new CircleF();
                        cirp.Center = new PointF( (float)(int)centrPoint[i, j, 1], (float)(int)centrPoint[i, j, 0] );
                        img.Draw( cirp, ApCenterPointColor, 1 );
                    }
                }
            }
            return img;
        }

        byte[,,] MatWhitePattern( int channal1, int channal2, int channal3 )
        {
            byte[,,] output = new byte[channal1,channal2,channal3];

            Parallel.For( 0, channal1, i => {
                for ( int j = 0; j < channal2; j++ )
                {
                    if ( i % 2 == 0 )
                    {
                        if ( j % 2 == 0 )
                        {
                            output[i, j, 0] = 250;
                            output[i, j, 1] = 250;
                            output[i, j, 2] = 250;
                        }
                        else
                        {
                            output[i, j, 0] = 250;
                            output[i, j, 1] = 250;
                            output[i, j, 2] = 250;
                        }
                    }
                    else if ( j % 2 == 0 )
                    {
                        output[i, j, 0] = 250;
                        output[i, j, 1] = 250;
                        output[i, j, 2] = 250;
                    }
                    else
                    {
                        output[i, j, 0] = 250;
                        output[i, j, 1] = 250;
                        output[i, j, 2] = 250;
                    }
                }
            } );
            return output;
        }

        byte[,,] MatPattern( int channal1, int channal2, int channal3 )
        {
            byte[,,] output = new byte[channal1,channal2,channal3];

            Parallel.For( 0, channal1, i => {
                for ( int j = 0; j < channal2; j++ )
                {
                    if ( i % 2 == 0 )
                    {
                        if ( j % 2 == 0 )
                        {
                            output[i, j, 0] = 250;
                            output[i, j, 1] = 250;
                            output[i, j, 2] = 250;
                        }
                        else
                        {
                            output[i, j, 0] = 150;
                            output[i, j, 1] = 150;
                            output[i, j, 2] = 150;
                        }
                    }
                    else if ( j % 2 == 0 )
                    {
                        output[i, j, 0] = 200;
                        output[i, j, 1] = 200;
                        output[i, j, 2] = 200;
                    }
                    else
                    {
                        output[i, j, 0] = 100;
                        output[i, j, 1] = 100;
                        output[i, j, 2] = 100;
                    }
                }
            } );
            return output;
        }


        void SetFailColor( byte[,,] failchipDisplayData, int j, int i )
        {
            failchipDisplayData[j, i, 0] = (byte)(failchipDisplayData[j, i, 0] * 0.3);
            failchipDisplayData[j, i, 1] = (byte)(failchipDisplayData[j, i, 1] * 0.5);
            failchipDisplayData[j, i, 2] = 200;
        }

        void SetLowColor( byte[,,] failchipDisplayData, int j, int i )
        {
            failchipDisplayData[j, i, 0] = 200;
            failchipDisplayData[j, i, 1] = (byte)(failchipDisplayData[j, i, 1] * 0.5);
            failchipDisplayData[j, i, 2] = (byte)(failchipDisplayData[j, i, 2] * 0.3);
        }

        void SetOverColor( byte[,,] failchipDisplayData, int j, int i )
        {
            failchipDisplayData[j, i, 0] = (byte)(failchipDisplayData[j, i, 0] * 0.3);
            failchipDisplayData[j, i, 1] = 200;
            failchipDisplayData[j, i, 2] = (byte)(failchipDisplayData[j, i, 2] * 0.5);
        }

    }
}
