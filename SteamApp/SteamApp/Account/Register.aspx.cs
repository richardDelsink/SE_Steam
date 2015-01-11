using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using SteamApp.Models;

namespace SteamApp.Account
{
    public partial class Register : Page
    {
        private DatabaseConnection db = new DatabaseConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorReg.Visible = false;

        }
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            RegisterCheck();
        }

        private void RegisterCheck()
        {
            db.RegSelect(RegisterName.Text);

            if (db.Naam == null)
            {
                db.AddUser(RegisterName.Text, ConfirmPassword.Text);

                Response.Redirect("Login.aspx");
            }

            else
            {
                ErrorReg.Visible = true;
            }
        }
    }
}