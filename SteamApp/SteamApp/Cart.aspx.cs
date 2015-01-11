using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Antlr.Runtime;

namespace SteamApp
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)

            {
                if (Session["Username"] != null)
                {
                    DataBind();
                }
                else
                {
                    Response.Redirect("~//Login.aspx");
                }
            }
        }

        protected void DataBind()
        {
            gvCartView.DataSource = ShopCart.Instance.Items;
            gvCartView.DataBind();
        }

        // remove item een fout id is niet
        protected void gvCartView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                int productId = Convert.ToInt32(e.CommandArgument);
                ShopCart.Instance.RemoveItem(productId);
            }
        }
       
        // op cell 4 moet totaal komen + bij elkaar opgetelde string, kan niet worden getest omdat niet de goede items worden toegevoegd
        protected void gvCartView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[3].Text = "Total" + ShopCart.Instance.GetSubTotal().ToString("");
            }
        }

        //update button zit een fout bij de update
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvCartView.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    try
                    {
                        int productId = Convert.ToInt32(gvCartView.DataKeys[row.RowIndex].Value);

                        int quantity = int.Parse(((TextBox) row.Cells[2].FindControl("tbQuantity")).Text);

                        ShopCart.Instance.SetItemQuantity(productId,quantity);
                    }
                    catch (Exception)
                    {
                        
                        throw;
                    }
                    DataBind();
                }
            }
        }
    }
}