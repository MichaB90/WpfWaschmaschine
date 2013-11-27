using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfWaschmaschine
{
    class cls__Global
    {
        public static cls_Kontroller g_oKontroller;
        public static cls_Motor g_oMotor;
        public static cls_MySqlDB g_oMySqlDb;
        public static cls_Waschmaschine g_oWaschmaschine;

        public static void InitClasses()
        {
            g_oKontroller = new cls_Kontroller();
            g_oMotor = new cls_Motor(MainWindow.frmMain);
            g_oMySqlDb = new cls_MySqlDB("","","","");
            g_oWaschmaschine = new cls_Waschmaschine(MainWindow.frmMain);
        }

    }
}
