﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SteamApp
{
    public partial class Contact : Page
    {
        private DatabaseConnection db = new DatabaseConnection();
        protected void Page_Load(object sender, EventArgs e)
        {// als je niet ingelogged ben dan wordt je naar de login ppagina verwezen
            if (Session["Username"] != null)
            {
                db.History(Grid1, Session["Username"].ToString());
            }
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }

        }
    }
}