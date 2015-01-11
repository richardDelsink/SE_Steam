using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace SteamApp
{
    public partial class About : Page
    {
        private DatabaseConnection db = new DatabaseConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Username"] != null)
                {
                    db.Library(Grid, Session["Username"].ToString());
                }
                else
                {
                    Response.Redirect("~//Login.aspx");
                }
            }

        }
       
    }
}