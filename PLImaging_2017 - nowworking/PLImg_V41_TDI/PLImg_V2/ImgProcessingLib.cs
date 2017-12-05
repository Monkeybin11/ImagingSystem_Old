using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;
using EmguCvExtension;

namespace PLImg_V2
{
    public class ImgProcessingLib
    {
        Func<Image<Gray,byte>, Image<Gray, byte>> PLProc =
            img =>
            {
                return null;
            };

        Func<Image<Gray,byte>, Image<Gray, byte>> ScterProc =
            img =>
            {
                return null;
            };
    }
}
