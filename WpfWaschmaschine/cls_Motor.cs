using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfWaschmaschine
{
    class cls_Motor 
    {
        bool visled_R;
        bool visled_n1;
        bool visled_n2;
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
        public enum Motorphasen
        {
            Leer = 0,
            Mindestens = 1,
            Hoechstens = 2
        }
    }
}
