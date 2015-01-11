using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;
using Oracle.DataAccess;
using System.Configuration;


namespace SteamApp
{
    public class DatabaseConnection
    {

        public string Naam { get; set; }
        
        public DatabaseConnection()
        {
            
        }

        #region login select query
        // kijken of er een iets wordt terug gegevn
        public string Login(string name, string password)
        {

            OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
            try
            {

                
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Username, Ispassword FROM DB21_Account WHERE Username = :name AND Ispassword = :password";
                cmd.Parameters.Add("Username", name);
                cmd.Parameters.Add("Ispassword", password);
                conn.Open();
                Naam = cmd.ExecuteScalar().ToString();

            }
            catch (Exception)
            {

                return Naam;
            }
            finally
            {
                conn.Close();
            }

            return Naam;


        }
        #endregion

        #region Adduser
        public void AddUser(string names, string passwords)
        {
            OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
            try
            {
                
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO DB21_Account (Username, Ispassword) VALUES(:names, :passwords)";
                cmd.Parameters.Add("Username", names);
                cmd.Parameters.Add("Ispassword", passwords);
                conn.Open();
                cmd.ExecuteReader();

            }
            catch (Exception )
            {
                

            }
            finally
            {
                conn.Close();
            }
           
        }
        #endregion

        #region select query voor register
        public string RegSelect(string name)
       {

           OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
           try
           {


               OracleCommand cmd = conn.CreateCommand();
               cmd.CommandText = "SELECT Username, Ispassword FROM DB21_Account WHERE Username = :name ";
               cmd.Parameters.Add("Username", name);
               conn.Open();
               Naam = cmd.ExecuteScalar().ToString();

           }
           catch (Exception)
           {

               
           }
           finally
           {
               conn.Close();
           }

           return Naam;


       }
       #endregion

        #region Library
        public void Library(GridView gv, string name)
        {

            OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
            try
            {
              

                conn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT i.ItemName, Product, IsCost FROM DB21_Account a, DB21_LibraryItem l, DB21_Item i WHERE l.UserID = a.UserID AND i.ItemID = l.ItemID AND Username =:name ORDER BY i.ITEMNAME";
                cmd.Parameters.Add("Username", name);
               
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet dt = new DataSet();
                adapter.Fill(dt);

                
                gv.DataSource = dt;
                gv.DataBind();

            }
            catch (Exception)
            {

                
            }
            finally
            {
                conn.Close();
            }

           


        }
        #endregion

        #region History
        public void History(GridView gv, string name)
        {
            // koop history inzien 
            OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
            try
            {


                conn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT ItemName, OrderDate, Price FROM DB21_Order o, DB21_Account a, DB21_Item i, DB21_Order_Regel ord WHERE o.OrderID = ord.OrderID AND o.UserID = a.UserID AND ord.ItemID = i.ItemID AND USername = :name ORDER BY i.ItemName";
                cmd.Parameters.Add("Username", name);
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet dt = new DataSet();
                adapter.Fill(dt);
                gv.DataSource = dt;
                gv.DataBind();

            }
            catch (Exception)
            {


            }
            finally
            {
                conn.Close();
            }




        }
        #endregion

    
    }
}