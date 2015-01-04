﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Configuration;

namespace SteamApp
{
    public class DatabaseConnection
    {
        private OracleConnection conn;

        public DatabaseConnection()
        {
            this.conn = new OracleConnection();
            this.conn.ConnectionString = ConfigurationManager.ConnectionStrings["SteamConnectionStrings"].ConnectionString;
            this.conn.Open();
            this.conn.Close();
        }

 

    }
}