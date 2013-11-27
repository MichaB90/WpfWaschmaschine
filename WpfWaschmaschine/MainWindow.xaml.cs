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
        public static IntPtr g_nPtrIOWarrior;
        public static MainWindow frmMain;
        bool m_Waerme3060;
        bool m_ModusNF;
        bool m_StatusOffOn;

        public MainWindow()
        {
            InitializeComponent();

            frmMain = this;

            //Verbindung zum IO Warrior herstellen
            g_nPtrIOWarrior = IOWarrior.Functions.IowKitOpenDevice();

            //Objekt der Waschmaschine erzeugen
            cls__Global.g_oWaschmaschine = new cls_Waschmaschine(this);
        }


        private void chk_Temp_Checked(object sender, RoutedEventArgs e)
        {
            if (chk_Temp.IsChecked == true)
                cls__Global.g_oWaschmaschine.m_oTemp = cls_Waschmaschine.Temperatur.Hoch;
            else
                cls__Global.g_oWaschmaschine.m_oTemp = cls_Waschmaschine.Temperatur.Niedrig;

        }
        private void chk_Modi_Checked(object sender, RoutedEventArgs e)
        {
            if (chk_Modi.IsChecked == true)
                cls__Global.g_oWaschmaschine.m_oModus = cls_Waschmaschine.Modus.Feinwaesche;
            else
                cls__Global.g_oWaschmaschine.m_oModus = cls_Waschmaschine.Modus.Normal; 

        }
        private void chk_Status_Checked(object sender, RoutedEventArgs e)
        {
            //led_pumperein.Visibility = Visibility.Visible;
            if(chk_Status.IsChecked == true)
                cls__Global.g_oWaschmaschine.m_oStatus = cls_Waschmaschine.Status.An;
            else
                cls__Global.g_oWaschmaschine.m_oStatus = cls_Waschmaschine.Status.Aus;
            //cls__Global.g_oKontroller.ReadValuesFromIntf();
        }

        private void chk_Temp_Unchecked(object sender, RoutedEventArgs e)
        {
            if (chk_Temp.IsChecked == true)
                cls__Global.g_oWaschmaschine.m_oTemp = cls_Waschmaschine.Temperatur.Hoch;
            else
                cls__Global.g_oWaschmaschine.m_oTemp = cls_Waschmaschine.Temperatur.Niedrig; 
        }

        private void chk_Modi_Unchecked(object sender, RoutedEventArgs e)
        {
            
        }

        private void chk_Status_Unchecked(object sender, RoutedEventArgs e)
        {
            //led_pumperein.Visibility = Visibility.Hidden;
            if (chk_Status.IsChecked == true)
                cls__Global.g_oWaschmaschine.m_oStatus = cls_Waschmaschine.Status.An;
            else
                cls__Global.g_oWaschmaschine.m_oStatus = cls_Waschmaschine.Status.Aus;
        }
    }
}
