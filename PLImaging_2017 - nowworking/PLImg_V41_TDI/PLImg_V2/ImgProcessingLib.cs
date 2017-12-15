using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;
using EmguCvExtension;
using System.Windows.Media.Imaging;
using System.Windows;
using Emgu.CV.CvEnum;
using System.Windows.Media;

namespace PLImg_V2
{
    public static class ImgProcessingLib
    {
        public static Func<Image<Gray,byte>, Image<Gray, byte>> PLProc =
            img =>
            {
                return null;
            };

        public static Func<Image<Gray,byte>, Image<Gray, byte>> ScterProc =
            img =>
            {
                return null;
            };

        [System.Runtime.InteropServices.DllImport( "gdi32.dll" )]
        public static extern bool DeleteObject( IntPtr handle );
        public static BitmapSource bs;

        public static BitmapSource ToBitmapSource( this IImage image )
        {
            using ( System.Drawing.Bitmap source = image.Bitmap )
            {
                IntPtr ptr = source.GetHbitmap(); //obtain the Hbitmap

                BitmapSource bs = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
            ptr,
            IntPtr.Zero,
            Int32Rect.Empty,
            System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());

                DeleteObject( ptr ); //release the HBitmap
                return bs;
            }
        }
        public static Mat ToMat( this BitmapSource source )
        {
            if ( source.Format == PixelFormats.Gray8 )
            {
                Mat result = new Mat();
                result.Create( source.PixelHeight, source.PixelWidth, DepthType.Cv8U, 1 );
                source.CopyPixels( Int32Rect.Empty, result.DataPointer, result.Step * result.Rows, result.Step );
                return result;
            }
            else
            {
                Mat result = new Mat();
                result.Create( source.PixelHeight, source.PixelWidth, DepthType.Cv8U, 3 );
                source.CopyPixels( Int32Rect.Empty, result.DataPointer, result.Step * result.Rows, result.Step );
                return result;
            }
        }

    }
}
