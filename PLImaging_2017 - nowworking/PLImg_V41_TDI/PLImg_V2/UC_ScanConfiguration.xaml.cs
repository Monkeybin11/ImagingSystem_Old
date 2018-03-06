using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PLImg_V2
{
	/// <summary>
	/// Interaction logic for UC_ScanConfiguration.xaml
	/// </summary>
	public partial class UC_ScanConfiguration : UserControl
	{
		public UC_ScanConfiguration()
		{
			InitializeComponent();
		}

		public double[] GetConfigs()
		{
			double ys = (double)nudystart.Value;
			double ye = (double)nudyend.Value;
			double x1 = (double)nudx1.Value;
			double x2 = (double)nudx2.Value;
			double x3 = (double)nudx3.Value;
			double x4 = (double)nudx4.Value;
			double x5 = (double)nudx5.Value;
			double x6 = (double)nudx6.Value;
			double x7 = (double)nudx7.Value;
			double linerate = (double)nudLineRAte.Value;
			double scanspeed = (double)nudScanSpeed.Value;

			return new double[]
			{
				ys,
				ye,
				x1,
				x2,
				x3,
				x4,
				x5,
				x6,
				x7,
				linerate,
				scanspeed
			};
		}

		public void Setconfig(double[] src)
		{
			nudystart.Value		= src[0]			;
			nudyend.Value		= src[1]			;
			nudx1.Value			= src[2]			;
			nudx2.Value			= src[3]			;
			nudx3.Value			= src[4]			;
			nudx4.Value			= src[5]			;
			nudx5.Value			= src[6]			;
			nudx6.Value			= src[7]			;
			nudx7.Value			= src[8]			;
			nudLineRAte.Value	= src[9]		;
			nudScanSpeed.Value	= src[10]	;
		}


		private void UserControl_Loaded( object sender, RoutedEventArgs e )
		{
			var basepath = AppDomain.CurrentDomain.BaseDirectory;
			var configname = "defulatConfig.csv";

			var fullpath = System.IO.Path.Combine(basepath,configname);

			if ( !File.Exists( fullpath ) )
			{
				var sb = new  StringBuilder();
				sb.Append( "168.5,60,154.7,132.6,110.5,88.4,66.3,44.2, 22.1,4280,8" );
				File.WriteAllText( fullpath, sb.ToString() );
			}
			FileStream fs = new FileStream(fullpath , FileMode.Open);
			StreamReader sr = new StreamReader(fs , Encoding.UTF8);
			var data = sr.ReadToEnd();
			sr.Close();
			fs.Close();

			var res = data.Split( ',' ).Select( x => double.Parse( x ) ).ToArray();
			Setconfig( res );
		}



	}
}
