using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChipProcessingLib
{
    public static class Core_Ext
    {
        public static double[,,] ActLoopOnChipPos(
           this double[,,] @this,
           List<System.Drawing.Rectangle> boxlsit,
           Action<int, int, double, double, List<System.Drawing.Rectangle>> loopAct )
        {
            try
            {
                for ( int j = 0; j < @this.GetLength( 0 ); j++ ) // row
                {
                    for ( int i = 0; i < @this.GetLength( 1 ); i++ ) // col
                    {
                        loopAct(
                            j, i
                            , @this[j, i, 0]
                            , @this[j, i, 1]
                            , boxlsit );
                    }
                }
                return @this;
            }
            catch
            {
                return @this;
            }
        }

    }
}
