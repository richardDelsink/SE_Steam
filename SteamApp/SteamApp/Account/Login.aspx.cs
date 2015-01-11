using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using SteamApp.Models;
using Oracle.DataAccess.Client;
using Oracle.DataAccess;
using System.Configuration;

namespace SteamApp.Account
{
    public partial class Login : Page
    {
        private DatabaseConnection db;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new DatabaseConnection();
            if (!IsPostBack)
            {
                
                //er wordt gekenen naar cookies als ze waar zijn worden ze aangemaakt
                if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
                {
                    UserName.Text = Request.Cookies["UserName"].Value;
                    Password.Attributes["value"] = Request.Cookies["Password"].Value;
                    RememberMe.Checked = true;
                }
            }
           
        }

        protected void LogIn(object sender, EventArgs e)
        {
            SteamLogin();     
        }

        #region Login check
        //inloggen
        private void SteamLogin()
        {
            //als de naam geen null waarde terug geeft dan is inloggen gelukt
            db.Login(UserName.Text, Password.Text);
            if (db.Naam != null)
            {
                Session["Username"] = UserName.Text;
                Session["Password"] = Password.Text;
                Error.Visible = false;

                // cookies remember me 30 dagen
                if (RememberMe.Checked == true)
                {
                    Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
                  
                }
                else
                {
                    // anders geen cookies 
                    Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
                }

                Response.Cookies["UserName"].Value = UserName.Text.Trim();
                Response.Cookies["Password"].Value = Password.Text.Trim();

                //default
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                // fout
                Error.Visible = true;
            }
        }

        #endregion



    }
}