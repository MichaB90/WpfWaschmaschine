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

        const string m_sServer = "localhost";  //default

        string m_sDatabase = "dbWaschmaschine;"; //default
        string m_sUser = "root;";
        string m_sPasswort = "Pass123;";
        string m_sPort = "80";


        public MySqlDB(string p_sPort, string p_sUser, string p_sPasswort)
        {
            m_sUser = p_sUser;
            m_sPasswort = p_sPasswort;
            m_sPort = p_sPort;

            Init();
        }

        private void Init()
        {
            OpenServer();

            //Datenbank anlegen
            string l_sSQLCommand = "CREATE DATABASE IF NOT EXISTS '" + m_sDatabase + "';";
            ExecuteCommand(l_sSQLCommand);


            //Tabellen anlegen
            l_sSQLCommand = "CREATE TABLE IF NOT EXISTS " + m_sDatabase + ".tblLog (ID INT, StatusID INT, Datum timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP);";
            ExecuteCommand(l_sSQLCommand);

            l_sSQLCommand = "CREATE TABLE IF NOT EXISTS " + m_sDatabase + ".tblStati (ID INT, StatusText VARCHAR(100));";
            ExecuteCommand(l_sSQLCommand);

            l_sSQLCommand = "CREATE TABLE IF NOT EXISTS " + m_sDatabase + ".tblTemp (ID INT, Temperatur INT, Modell varchar(100));";
            ExecuteCommand(l_sSQLCommand);
            
            l_sSQLCommand = "CREATE TABLE IF NOT EXISTS " + m_sDatabase + ".tblModi (ID INT, Modi varchar(1), Modell varchar(100));";
            ExecuteCommand(l_sSQLCommand);

            l_sSQLCommand = "CREATE TABLE IF NOT EXISTS " + m_sDatabase + ".tblWaschmaschine (ID INT, Modell varchar(100), LogID INT);";
            ExecuteCommand(l_sSQLCommand);

        }

        //Öffnet den Server
        public bool OpenServer()
        {
            try
            {
                string l_sConnectionString = "";
                l_sConnectionString = "SERVER=" + m_sServer + ";PORT=" + m_sPort + ";UID=" + m_sUser + ";PASSWORD=" + m_sPasswort + ";";
                myConnection = new MySqlConnection(l_sConnectionString);
                myConnection.Open();
                return true;
            }
            catch (MySqlException e)
            {
                System.Windows.MessageBox.Show(e.Message);
                return false;
            }
            catch (Exception)
            {
                return false;
            }

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
            catch (MySqlException e)
            {
                System.Windows.MessageBox.Show(e.Message);
                return false;
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
            catch (MySqlException e)
            {
                System.Windows.MessageBox.Show(e.Message);
                return false;
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
            catch (MySqlException e)
            {
                System.Windows.MessageBox.Show(e.Message);
                return false;
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
            catch (MySqlException e)
            {
                System.Windows.MessageBox.Show(e.Message);
                return false;
            }
            catch (Exception)
            {
                l_oReturn = -1;
            }

            return l_oReturn;
        }

    }
}
