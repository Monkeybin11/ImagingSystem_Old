using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace PLImg_V2
{
    public static class BitmapSrcConvert
    {
        [DllImport( "gdi32" )]
        private static extern int DeleteObject( IntPtr o );

        public static BitmapSource ToBitmapSource( IImage image )
        {
            try
            {
                using ( System.Drawing.Bitmap source = image.Bitmap )
                {
                    IntPtr ptr = source.GetHbitmap();

                    BitmapSource bs = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                ptr,
                IntPtr.Zero,
                Int32Rect.Empty,
                System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());

                    DeleteObject( ptr );
                    return bs;
                }
            }
            catch ( Exception )
            {
                return null;
            }

        }
    }
}
