using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.ComponentModel;
using System.Diagnostics;
namespace WpfWaschmaschine
{
    class cls_Motor 
    {
        MainWindow frmMain;
        bool visled_R;
        bool visled_n1;
        bool visled_n2;

        public cls_Motor(MainWindow p_frmMain)
        {
            frmMain = p_frmMain;
           
            
        }

        public bool Motordrehtnormal()
        {
            bool l_bReturn = false;        
                Thread doSetMotNormal = null;
                doSetMotNormal.Start();
                //Thread.Sleep(1000);
                frmMain.led_n1.Visibility = System.Windows.Visibility.Visible;
                frmMain.led_n2.Visibility = System.Windows.Visibility.Hidden;
                frmMain.led_R.Visibility = System.Windows.Visibility.Hidden;
                Thread.Sleep(1000);
                frmMain.led_n1.Visibility = System.Windows.Visibility.Hidden;
                frmMain.led_n2.Visibility = System.Windows.Visibility.Visible;
                frmMain.led_R.Visibility = System.Windows.Visibility.Hidden;
                Thread.Sleep(1000);
                frmMain.led_n1.Visibility = System.Windows.Visibility.Hidden;
                frmMain.led_n2.Visibility = System.Windows.Visibility.Hidden;
                frmMain.led_R.Visibility = System.Windows.Visibility.Visible;
                Thread.Sleep(1000);
            return l_bReturn;
        }
        public bool Motorstopt()
        {
            bool l_bReturn = false;
            Thread doSetMotNormal = null;
            doSetMotNormal.Start();
            //Thread.Sleep(1000);
            frmMain.led_n1.Visibility = System.Windows.Visibility.Visible;
            frmMain.led_n2.Visibility = System.Windows.Visibility.Hidden;
            frmMain.led_R.Visibility = System.Windows.Visibility.Hidden;
            Thread.Sleep(3000);
            frmMain.led_n1.Visibility = System.Windows.Visibility.Hidden;
            frmMain.led_n2.Visibility = System.Windows.Visibility.Visible;
            frmMain.led_R.Visibility = System.Windows.Visibility.Hidden;
            Thread.Sleep(4000);
            frmMain.led_n1.Visibility = System.Windows.Visibility.Hidden;
            frmMain.led_n2.Visibility = System.Windows.Visibility.Hidden;
            frmMain.led_R.Visibility = System.Windows.Visibility.Visible;
            Thread.Sleep(5000);
            frmMain.led_n1.Visibility = System.Windows.Visibility.Hidden;
            frmMain.led_n2.Visibility = System.Windows.Visibility.Hidden;
            frmMain.led_R.Visibility = System.Windows.Visibility.Hidden;
            return l_bReturn;
        } 
    }
}
