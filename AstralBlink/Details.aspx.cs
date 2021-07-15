using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UserService Details = new UserService();
            string id = Request.QueryString["id"];//קבלת קוד משחק מהדף הקודם
            Connection con = new Connection();
            OleDbConnection connect = new OleDbConnection(con.GetConString());
            OleDbCommand CMD = new OleDbCommand("SelectGame", connect);
            CMD.CommandType = CommandType.StoredProcedure;
            OleDbParameter objParam = new OleDbParameter("@GameCode", OleDbType.BSTR);
            objParam.Value = id;
            CMD.Parameters.Add(objParam);
            OleDbDataAdapter DA = new OleDbDataAdapter(CMD);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            DetailsDataList.DataSource = DS;
            DetailsDataList.DataBind();
            if(Session["Username"]==null)//אם המשתמש לא מחובר לא להראות את לחצן ה showdown
            {
                foreach(DataListItem item in DetailsDataList.Items)
                {
                    ImageButton redeem = (ImageButton)item.FindControl("RedeemFreeBtn");
                    redeem.Visible = false;
                        
                }
            }
        }
    }





    protected void DetailsDataList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void AddToCartBtn_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void DetailsDataList_ItemCommand(object source, DataListCommandEventArgs e)//שולח את המשתמש לעגלת הקניות
    {
        if (e.CommandName == "AddToCart")
        {
            Response.Redirect("ShoppingCart.aspx?id=" + e.CommandArgument.ToString());
        }
        if(e.CommandName=="RedeemToCart")
        {
            ShowdownWS.ShowdownWS game = new ShowdownWS.ShowdownWS();
            if (game.UseWin(Session["Username"].ToString()))//אם יש ניצחון לא ממומש
            {
                Response.Redirect("ShoppingCart.aspx?id=" + e.CommandArgument.ToString() + "&NewPrice=0");
            }
            else
            {
                ErorLbl.Text = "You don't have any unredeemed showdown wins";
                ErorLbl.Visible = true;
            }
        }
    }

    protected void RedeemFreeBtn_Click(object sender, ImageClickEventArgs e)
    {

    }
}