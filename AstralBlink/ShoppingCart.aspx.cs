using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;

public partial class ShoppingCart : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["username"] == null)
        {
            Response.Redirect("Login.aspx");
        }

        string username = Session["Username"].ToString();

        if (!IsPostBack)
        {
            Cart SCart = new Cart(username);
            DataTable dt = SCart.BuildCart();
            DataRow dr;

            if (Request.QueryString["id"] != null)//אם נשלח מהדף הקודם משחק
            {
                if (Session["Buyitems"] == null)//אם אין למשתמש פריטים בסל
                {

                    dr = dt.NewRow();

                    Connection Mycon = new Connection();
                    OleDbConnection scon = new OleDbConnection(Mycon.GetConString());
                    String myquery = "select * from Games where GameCode=" + Request.QueryString["id"];
                    OleDbCommand cmd = new OleDbCommand(myquery,scon);
                    OleDbDataAdapter da = new OleDbDataAdapter();
                    da.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    dr["Count"] = 1;
                    dr["GameCode"] = ds.Tables[0].Rows[0]["GameCode"].ToString();
                    dr["GameNameEN"] = ds.Tables[0].Rows[0]["GameNameEN"].ToString();
                    dr["GameImage"] = ds.Tables[0].Rows[0]["GameImage"].ToString();
                    if (Request.QueryString["NewPrice"] != null)
                        dr["GamePrice"] = 0;
                    else
                        dr["GamePrice"] = ds.Tables[0].Rows[0]["GamePrice"].ToString();
                    SCart.SaveCartDetails(ds.Tables[0].Rows[0]["GameCode"].ToString(), ds.Tables[0].Rows[0]["GameNameEN"].ToString(), ds.Tables[0].Rows[0]["GameImage"].ToString(), ds.Tables[0].Rows[0]["GamePrice"].ToString());

                    dt.Rows.Add(dr);
                    ShoppingCartGrid.DataSource = dt;
                    ShoppingCartGrid.DataBind();

                    Session["buyitems"] = dt;//עדכון עם הרשומה החדשה
                    ShoppingCartGrid.FooterRow.Cells[3].Text = "Total Amount in ILS";
                    ShoppingCartGrid.FooterRow.Cells[4].Text = grandtotal().ToString();
                    Response.Redirect("ShoppingCart.aspx");

                }
                else//אם נשלח משחק מדף קודם ולמשתמש יש משחקים בסל
                {

                    dt = (DataTable)Session["buyitems"];
                    //int sr;
                    Cart CountRow = new Cart(Session["Username"].ToString());
                    //sr = CountRow.CheckRowCart(); // כמות השורות בטבלה הכוללת

                    dr = dt.NewRow();
                    Connection Mycon = new Connection();
                    OleDbConnection scon = new OleDbConnection(Mycon.GetConString());
                    String myquery = "select * from Games where GameCode=" + Request.QueryString["id"];
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandText = myquery;
                    cmd.Connection = scon;
                    OleDbDataAdapter da = new OleDbDataAdapter();
                    da.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dr["Count"] = dt.Rows.Count + 1; // כמות השורות של הקונה +1  
                    dr["GameCode"] = ds.Tables[0].Rows[0]["GameCode"].ToString();
                    dr["GameNameEN"] = ds.Tables[0].Rows[0]["GameNameEN"].ToString();
                    dr["GameImage"] = ds.Tables[0].Rows[0]["GameImage"].ToString();
                    if (Request.QueryString["NewPrice"] != null)
                        dr["GamePrice"] = 0;
                    else
                        dr["GamePrice"] = ds.Tables[0].Rows[0]["GamePrice"].ToString();
                    SCart.SaveCartDetails(ds.Tables[0].Rows[0]["GameCode"].ToString(), ds.Tables[0].Rows[0]["GameNameEN"].ToString(), ds.Tables[0].Rows[0]["GameImage"].ToString(), ds.Tables[0].Rows[0]["GamePrice"].ToString());
                    dt.Rows.Add(dr);
                    ShoppingCartGrid.DataSource = dt;
                    ShoppingCartGrid.DataBind();
                    Session["buyitems"] = dt;
                    ShoppingCartGrid.FooterRow.Cells[3].Text = "Total Amount in ILS";
                    ShoppingCartGrid.FooterRow.Cells[4].Text = grandtotal().ToString();
                    Response.Redirect("ShoppingCart.aspx");

                }
            }
            else//אם לא נשלח משחק מדף קודם
            {
                dt = (DataTable)Session["buyitems"];
                ShoppingCartGrid.DataSource = dt;
                ShoppingCartGrid.DataBind();
                if (ShoppingCartGrid.Rows.Count > 0)//אם יש למשתמש פריטים בסל
                {
                    ShoppingCartGrid.FooterRow.Cells[3].Text = "Total Amount in ILS";
                    ShoppingCartGrid.FooterRow.Cells[4].Text = grandtotal().ToString();
                }
                else//אם אין פריטים
                {
                    CheckoutBtn.Visible = false;
                    ClearCartBtn.Visible = false;
                    EmptyLbl.Visible = true;
                }


            }

        }

    }

 

    public int grandtotal()//Sums the total price of all products in cart
    {
        DataTable dt = new DataTable();
        dt = (DataTable)Session["buyitems"];
        int nrow = dt.Rows.Count;
        
        int gtotal = 0;
        for(int i = 0; i < nrow;i++)
        {
            gtotal = gtotal + Convert.ToInt32(dt.Rows[i]["GamePrice"].ToString());

        }
        return gtotal;
    }


    protected void ClearCartBtn_Click(object sender, EventArgs e)//clears saved cart details for logged user
    {
        Session["buyitems"] = null;
        Cart ClearCrat = new Cart(Session["Username"].ToString());
        ClearCrat.ClearSavedCart();
        Response.Redirect("Store.aspx");
    }

    protected void ShoppingCartGrid_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void CheckoutBtn_Click(object sender, ImageClickEventArgs e)//redirect to checkout page with total price 
    {
        Session["TPrice"] = ShoppingCartGrid.FooterRow.Cells[4].Text;
        Response.Redirect("Checkout.aspx");
    }
}