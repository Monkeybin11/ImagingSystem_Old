using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace PLImg_V2
{
    /// <summary>
    /// Interaction logic for WIn_AreaView.xaml
    /// </summary>
    public partial class Win_AreaView : Window
    {
        public event Action evtClosing;
        public Win_AreaView()
        {
            InitializeComponent();
        }

        private void Window_Closing( object sender, System.ComponentModel.CancelEventArgs e )
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
            evtClosing();
        }




        public void UpdateImg( Image<Gray, byte> img )
        {
            imgboxArea.Image = img;
        }

    }
}
