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
using IOWarrior;

namespace WpfWaschmaschine
{

    public partial class MainWindow : Window
    {
        cls_Waschmaschine m_oWaschmaschne;
        public static IntPtr g_nPtrIOWarrior;


        public MainWindow()
        {
            InitializeComponent();

            //Verbindung zum IO Warrior herstellen
            g_nPtrIOWarrior = IOWarrior.Functions.IowKitOpenDevice();

            //Objekt der Waschmaschine erzeugen
            m_oWaschmaschne = new cls_Waschmaschine();
        }


        private void chk_Temp_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void chk_Modi_Checked(object sender, RoutedEventArgs e)
        {
            
        }
        private void chk_Status_Checked(object sender, RoutedEventArgs e)
        {
            led_pumperein.Visibility = Visibility.Visible;
        }

        private void chk_Temp_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void chk_Modi_Unchecked(object sender, RoutedEventArgs e)
        {
            
        }

        private void chk_Status_Unchecked(object sender, RoutedEventArgs e)
        {
            led_pumperein.Visibility = Visibility.Hidden;
        }
    }
}
