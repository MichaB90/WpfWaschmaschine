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
        Temperatur m_oTemp;
        Status m_oStatus;
        Modus m_oModus;
        Wasserstand m_oWasser;
        bool visled_H2;
        bool visled_H1;
        bool visled_60;
        bool visled_30;
        bool visled_www;
        bool visled_pumperaus;
        bool visled_pumperein;
        System.Timers.Timer t_time = new System.Timers.Timer();
        //Konstruktor
        public cls_Waschmaschine()
        {
            m_oTemp = Temperatur.Niedrig;
            m_oStatus = Status.Aus;
            m_oModus = Modus.Normal;
       
            ReadValuesFromIntf();
        }

        //Lies die gesetzten Werte aus der Schnittstelle aus
        public void ReadValuesFromIntf()
        { 
            
        }
        //erwärmen
        public bool Erwaermen()
        {
            bool l_bReturn = false;

            if (m_oTemp == Temperatur.Niedrig)
            {
                Thread doSetNiedrig = null;
                doSetNiedrig.Start();
                Thread.Sleep(2000);
                
                l_bReturn = true;
            }
            else if (m_oTemp == Temperatur.Hoch)
            {
                Thread doSetNiedrig = null;
                doSetNiedrig.Start();
                Thread.Sleep(2000);

                Thread doSetHoch = null;
                doSetHoch.Start();
                Thread.Sleep(2000);
                
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
                Thread.Sleep(2000);

                l_bReturn = true;
            }
            else if (m_oWasser == Wasserstand.Hoechstens)
            {
                Thread doSetMindestens = null;
                doSetMindestens.Start();
                Thread.Sleep(2000);

                Thread doSetHoechstens = null;
                doSetHoechstens.Start();
                Thread.Sleep(2000);

                l_bReturn = true;
            }
            else
            {
                //Keine Temperatur also Fehler
                l_bReturn = false;
            }

            return l_bReturn;
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

    }
   
    
}
