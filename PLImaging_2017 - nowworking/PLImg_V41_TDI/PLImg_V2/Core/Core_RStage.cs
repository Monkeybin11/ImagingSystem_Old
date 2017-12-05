using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLImg_V2
{
    partial class Core_RStage
    {
        RStage RStg = new RStage("COM3");
        public Core_RStage()
        {
            RStg.Open();
            RStg.SendAndReady( "S:15" );

            var str = RStg.SetSpeed
                + "1"
                + ( 20000 ).ToSpeed();

            RStg.SendAndReady( str );

            RStg.SendAndReady( "V:"
               + "1"
               + (20000).ToSpeed());
        }

        public void UpdatePos(double degree)
        {
            RStg.SendAndReady( RStg.GoRel + degree.Degree2Pulse().ToPos());
            RStg.SendAndReady( RStg.Go );
        }

        public void Origin()
        {
            RStg.SendAndReady( RStg.Home + "1");
        }

    }
}
