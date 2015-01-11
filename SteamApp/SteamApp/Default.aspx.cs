using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Antlr.Runtime;
using Microsoft.Ajax.Utilities;
using Oracle.DataAccess.Client;
using Oracle.DataAccess;
using System.Configuration;


namespace SteamApp
{
    public partial class _Default : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        protected void btnAddCart_Click(object sender, EventArgs e)
        {

        }

        // als er in de grid iets veranderd item toevoegen
        protected void dlItems_ItemCommand(object source, DataListCommandEventArgs e)
        {
            Label s = (Label)e.Item.FindControl("ITEMIDLABEL");
            int itemID = int.Parse(s.Text);
            ShopCart.Instance.AddItem(itemID);

        }

        protected void btnViewCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cart.aspx");
        }
    }
}