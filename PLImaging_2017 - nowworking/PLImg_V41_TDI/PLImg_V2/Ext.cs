using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLImg_V2.Data;

namespace PLImg_V2
{
	public static class Ext
	{
		public static TriggerScanData_New ToScanData( this double[] paramList )
			=> new TriggerScanData_New( paramList );
	}
}
