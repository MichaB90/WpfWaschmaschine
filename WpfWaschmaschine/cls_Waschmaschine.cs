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
    class cls_Waschmaschine
    {
        //Klassenvariablen
        public Temperatur m_oTemp;
        public Status m_oStatus;
        public Modus m_oModus;
        public Wasserstand m_oWasser;
        public MainWindow frmMain;
        public Pumperaus m_oRauspumpen;
        public Pumperein m_oReinpumpen;

        //public bool visled_H2;
        //public bool visled_H1;
        //public bool visled_60;
        //public bool visled_30;
        //public bool visled_www;
        //public bool visled_pumperaus;
        //public bool visled_pumperein;

        System.Timers.Timer t_time = new System.Timers.Timer();
        //Konstruktor
        public cls_Waschmaschine(MainWindow p_frmMain)
        {
            m_oTemp = Temperatur.Niedrig;
            m_oStatus = Status.Aus;
            m_oModus = Modus.Normal;
            m_oRauspumpen = Pumperaus.Aus;
            m_oReinpumpen = Pumperein.Aus;
            frmMain = p_frmMain;
        }

        public bool Reinpumpen()
        {
            bool l_bReturn = false;
            if (m_oReinpumpen == Pumperein.An)
            {
                Thread doSetReinpumpen = null;
                doSetReinpumpen.Start();
                frmMain.led_pumperein.Visibility = System.Windows.Visibility.Visible;
                frmMain.led_pumperaus.Visibility = System.Windows.Visibility.Hidden;
                l_bReturn = true;
            }
            else if (m_oReinpumpen == Pumperein.Aus)
            {
                Thread doSetReinpumpen = null;
                doSetReinpumpen.Start();
                frmMain.led_pumperein.Visibility = System.Windows.Visibility.Hidden;
                l_bReturn = true;
            }
            else
            {
                l_bReturn = false;
            }

            return l_bReturn;
           // return;
        }
        public bool Rauspumpen()
        {
            bool l_bReturn = false;
            if (m_oRauspumpen == Pumperaus.An)
            {
                Thread doSetRauspumpen = null;
                doSetRauspumpen.Start();
                frmMain.led_pumperein.Visibility = System.Windows.Visibility.Hidden;
                frmMain.led_pumperaus.Visibility = System.Windows.Visibility.Visible;
                l_bReturn = true;
            }
            else if (m_oRauspumpen == Pumperaus.Aus)
            {
                Thread doSetRauspumpen = null;
                doSetRauspumpen.Start();
                frmMain.led_pumperaus.Visibility = System.Windows.Visibility.Hidden;
                l_bReturn = true;
            }
            else
            {
                //Keine Temperatur also Fehler
                l_bReturn = false;
            }

            return l_bReturn;
           // return;
        }
        //erwärmen
        public bool Erwaermen()
        {
            bool l_bReturn = false;

            if (m_oTemp == Temperatur.Niedrig)
            {
                Thread doSetNiedrig = null;
                doSetNiedrig.Start();
                frmMain.led_60.Visibility = System.Windows.Visibility.Hidden;
                frmMain.led_www.Visibility = System.Windows.Visibility.Visible;
                Thread.Sleep(3000);
                frmMain.led_30.Visibility = System.Windows.Visibility.Visible;
                
                l_bReturn = true;
            }
            else if (m_oTemp == Temperatur.Hoch)
            {
                Thread doSetNiedrig = null;
                doSetNiedrig.Start();
                Thread.Sleep(3000);
                frmMain.led_30.Visibility = System.Windows.Visibility.Visible;
                frmMain.led_60.Visibility = System.Windows.Visibility.Hidden;

                Thread doSetHoch = null;
                doSetHoch.Start();
                Thread.Sleep(3000);
                frmMain.led_30.Visibility = System.Windows.Visibility.Hidden;
                frmMain.led_60.Visibility = System.Windows.Visibility.Visible;
                
                l_bReturn = true;
            }
            else
            {
                //Keine Temperatur also Fehler
                l_bReturn = false;
            }

            return l_bReturn;
        }
        public bool Pruef_Wasser()
        {
            bool l_bReturn = false;

            if (m_oWasser == Wasserstand.Mindestens)
            {
                Thread doSetMindestens = null;
                doSetMindestens.Start();
                Thread.Sleep(3000);
                frmMain.led_H1.Visibility = System.Windows.Visibility.Visible;
                frmMain.led_H2.Visibility = System.Windows.Visibility.Hidden;
                frmMain.led_pumperein.Visibility = System.Windows.Visibility.Hidden;

                l_bReturn = true;
            }
            else if (m_oWasser == Wasserstand.Hoechstens)
            {
                Thread doSetMindestens = null;
                doSetMindestens.Start();
                Thread.Sleep(3000);
                frmMain.led_H1.Visibility = System.Windows.Visibility.Visible;
                frmMain.led_H2.Visibility = System.Windows.Visibility.Hidden;


                Thread doSetHoechstens = null;
                doSetHoechstens.Start();
                Thread.Sleep(3000);
                frmMain.led_H1.Visibility = System.Windows.Visibility.Hidden;
                frmMain.led_H2.Visibility = System.Windows.Visibility.Visible;
                frmMain.led_pumperein.Visibility = System.Windows.Visibility.Hidden;
                l_bReturn = true;
            }
            else
            {
                //Keine Temperatur also Fehler
                l_bReturn = false;
            }

            return l_bReturn;
        }

        public static void StarteWaschvorgang()
        {
            cls__Global.g_oKontroller.ReadValuesFromIntf();
            
            cls__Global.g_oWaschmaschine.Pruef_Wasser();
            cls__Global.g_oWaschmaschine.Erwaermen();

            
            
        }

        //Enumerationen
        public enum Temperatur
        {
            Niedrig = 30,
            Hoch = 60
        }
        public enum Status
        {
            An = 1,
            Aus = 0
        }
        public enum Modus
        {
            Normal = 0,
            Feinwaesche = 1
        }
        public enum Wasserstand
        {
            Leer = 0,
            Mindestens = 1,
            Hoechstens = 2
        }
        public enum Pumperein
        {
            An = 1,
            Aus = 0

        }
        public enum Pumperaus
        {
            An = 1,
            Aus = 0
        }

    }
   
    
}
