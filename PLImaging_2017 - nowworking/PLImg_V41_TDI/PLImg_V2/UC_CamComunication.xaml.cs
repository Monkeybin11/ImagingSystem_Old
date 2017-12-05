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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ApplicationUtilTool.Communication;
using System.IO.Ports;
using System.Threading;

namespace PLImg_V2
{
    /// <summary>
    /// Interaction logic for UC_CamComunication.xaml
    /// </summary>
    public partial class UC_CamComunication : UserControl
    {
        RS232 RsCom;
        SerialPort Port;
        public event Action evtOpenAreaView;
        public event Action evtOpenAlignView;

        public UC_CamComunication()
        {
            InitializeComponent();
            Port = new SerialPort();
            if ( !Port.IsOpen )
            {
                Console.WriteLine( "Port is null" );
                Port.PortName = "COM7";
                Port.BaudRate = 115200;
                Port.DataBits = 8;
                Port.Parity = Parity.None;
                Port.Handshake = Handshake.None;
                Port.StopBits = StopBits.One;
                Port.Encoding = Encoding.UTF8;
            }
            Console.WriteLine( "Port is opend" );

            RsCom = new RS232( Port, CommandEndStyle.CR, SendStyle.String, 500 , false);
            RsCom.Open();
        }

        public bool Open()
        {
            return RsCom.Open();
        }

        private void WevtSend( object sender, KeyEventArgs e )
        {
            if ( e.Key == Key.Enter )
            {
                this.Dispatcher.BeginInvoke( (Action)(() => textBox.Act( x => x.Clear() )
                                                                   .Act( x => x.Text = QueryText() )));
            }
        }

        private void btnSend_Click( object sender, RoutedEventArgs e )
        {
            this.Dispatcher.BeginInvoke( (Action)(() => textBox.Act( x => x.Clear() )
                                                               .Act( x => x.Text = QueryText() )));
        }

        string QueryText()
        => RsCom.Query( txbmsg.Text.Trim() );

        private void btnArea_Click( object sender, RoutedEventArgs e )
        {
            string tdi = "tdi 0";
            string ssf = "ssf 3" ;

            RsCom.Query( tdi );
            Thread.Sleep( 100 );
            RsCom.Query( ssf );
        }

        private void btnLine_Click( object sender, RoutedEventArgs e )
        {
            SetLine();
        }

        public void SetLine()
        {
            string tdi = "tdi 1";
            string ssf = "ssf 4280";
            RsCom.Query( tdi );
            Thread.Sleep( 100 );
            RsCom.Query( ssf );
        }

        private void btnViewArea_Click( object sender, RoutedEventArgs e )
        {
            string tdi = "tdi 0";
            string ssf = "ssf 3" ;

            RsCom.Query( tdi );
            Thread.Sleep( 100 );
            RsCom.Query( ssf );

            evtOpenAreaView();
        }

        public void SetLineRate( int val )
            => RsCom.Query( "ssf " + val.ToString() );

        private void btnAlign_Click( object sender, RoutedEventArgs e )
        {
            string tdi = "tdi 0";
            string ssf = "ssf 3" ;

            RsCom.Query( tdi );
            Thread.Sleep( 100 );
            RsCom.Query( ssf );

            evtOpenAlignView();
        }
    }
}
