using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using Oracle.DataAccess;
using System.Configuration;

namespace SteamApp
{
    public class Item
    {
        DatabaseConnection db = new DatabaseConnection();
        public string ItemName { get; set; }
        public string ItemInfo { get; set; }
        public int IsCost { get; set; }

        #region constructor 
        // opvragen van waardes
        public Item(int item)
        {
            OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
            try
            {
                string ItemName = "SELECT ItemName FROM DB21_Item WHERE ItemID =:item";
                string ItemInfo = "SELECT ItemInfo FROM DB21_Item WHERE ItemID =:item";
                string Cost = "SELECT IsCost FROM DB21_Item WHERE ItemID =:item";

                OracleCommand cmd = new OracleCommand(ItemName, conn);
                OracleCommand cmd2 = new OracleCommand(ItemInfo, conn);
                OracleCommand cmd3 = new OracleCommand(Cost, conn);
                cmd.Parameters.Add("ItemID", item);
                cmd2.Parameters.Add("ItemID", item);
                cmd3.Parameters.Add("ItemID", item);

                conn.Open();
                ItemName = Convert.ToString(cmd.ExecuteScalar());
                ItemInfo = Convert.ToString(cmd.ExecuteScalar());
                IsCost = Convert.ToInt32(cmd.ExecuteScalar());



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