using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace WpfWaschmaschine
{
    class MySqlDB
    {
        MySqlConnection myConnection;
        MySqlCommand myCommand;
        

        string m_sServer = "localhost;";
        string m_sDatabase = "mydatabase;";
        string m_sUser = "user;";
        string m_sPasswort = "mypassword;";


        public MySqlDB(string p_sServer, string p_sDatabase, string p_sUser, string p_sPasswort)
        {
            m_sServer = p_sServer;
            m_sDatabase = p_sDatabase;
            m_sUser = p_sUser;
            m_sPasswort = p_sPasswort;
        }


        //Öffnet die Datenbank
        public bool OpenDatabase()
        {
            try
            {
                string l_sConnectionString = "SERVER=" + m_sServer + ";DATABASE=" + m_sDatabase + ";UID=" + m_sUser + ";PASSWORD=" + m_sPasswort + ";";
                myConnection = new MySqlConnection(l_sConnectionString);
                myConnection.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
        //Schließt die Datenbank
        public bool CloseDatabase()
        {
            try
            {
                myConnection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        //Führt einen SQL Befehl aus
        public int ExecuteCommand(string p_sCommand)
        {
            int l_nReturn = 0;

            try
            {
                this.OpenDatabase();
                l_nReturn = myCommand.ExecuteNonQuery();
                this.CloseDatabase();
            }
            catch (Exception)
            {
                l_nReturn = -1;
            }

            return l_nReturn;
        }

        //Ruft den Inhalt einer Tabelle einer bestimmten Zelle ab
        public object ReadValue(string p_sCommand)
        {
            object l_oReturn; ;

            try
            {
                this.OpenDatabase();
                l_oReturn = myCommand.ExecuteScalar();
                this.CloseDatabase();
            }
            catch (Exception)
            {
                l_oReturn = -1;
            }

            return l_oReturn;
        }

    }
}
