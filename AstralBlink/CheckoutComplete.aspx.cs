using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CheckoutComplete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            ShowdownWS.ShowdownWS game = new ShowdownWS.ShowdownWS();
            Session["buyitems"] = null;
            Cart ClearCrat = new Cart(Session["Username"].ToString());
            ClearCrat.ClearSavedCart();//מוחק את ערכי עגלת הקניות של המשתמש
            int Price = int.Parse(Session["TPrice"].ToString());
            game.AddGames(Session["Username"].ToString(),Price / 50);//מוסיף לפי המחיר הכולל זכאות למשחקים ב showdown
            PriceLbl.Text = Price.ToString();
            Session["TPrice"] = null;
            if(Session["Convert"]!=null)
            {
                ConvertedLbl.Text = "or " + Session["Convert"].ToString();
            }
        }
    }
}