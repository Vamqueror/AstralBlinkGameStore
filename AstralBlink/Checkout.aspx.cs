using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class Checkout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            OrderDateLbl.Text = DateTime.Now.ToShortDateString();
            findorderid();

            DataTable dt = new DataTable();
            dt = (DataTable)Session["buyitems"];
            ShoppingCartGrid.DataSource = dt;
            ShoppingCartGrid.DataBind();

            ShoppingCartGrid.FooterRow.Cells[3].Text = "Total Price";
            ShoppingCartGrid.FooterRow.Cells[4].Text = Session["TPrice"].ToString()+ "₪";
            DataTable dt1 = BuildOrderTable();
            DataRow dr;
            dr = dt1.NewRow();//creates new row to show order details
            dr["Order ID"] = OrderIdLbl.Text;
            dr["Username"] = Session["username"].ToString();
            dr["Total Price"] = Session["TPrice"].ToString();
            dr["Date Of Order"] = OrderDateLbl.Text;
            dt1.Rows.Add(dr);
            OrderDetailsGrid.DataSource = dt1;
            OrderDetailsGrid.DataBind();
            UserService us1 = new UserService();
            string country = us1.RunSingleStoredQuery("GetCountry", Session["Username"].ToString(), "Username").ToString();
            if (country != "Israel")
            {
                string currency = us1.RunSingleStoredQuery("GetCurrency", country, "Country").ToString();
                ConventorWS.Converter convert = new ConventorWS.Converter();
                decimal newPrice = convert.GetConversionAmount("ILS", currency, convert.GetLastUpdateDate(), int.Parse(Session["TPrice"].ToString()));
                ShoppingCartGrid.FooterRow.Cells[4].Text += " /" + String.Format("{0:0.00}", newPrice) + currency;
                Session["Convert"] = String.Format("{0:0.00}", newPrice) + currency;
            }
        }
    }
  

    public void findorderid()//returns order ID
    {
        String pass = "abcdefghijklmnopqrstuvwxyz123456789";
        Random r = new Random();
        char[] mypass = new char[5];
        for (int i = 0; i < 5; i++)
        {
            mypass[i] = pass[(int)(35 * r.NextDouble())];//generates random order ID number

        }
        String orderid;
        orderid = "Order" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + new string(mypass);

        OrderIdLbl.Text = orderid;


    }

    public static DataTable BuildOrderTable()//builds DataTable for orders
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Order ID");
        dt.Columns.Add("Username");

        dt.Columns.Add("Total Price");

        dt.Columns.Add("Date Of Order");
        return dt;
    }

    protected void ShoppingCartGrid_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void OrderDetailsGrid_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void CheckOutBtn_Click(object sender, ImageClickEventArgs e)
    {
        CreditCardWS.CreditCardWS obj = new CreditCardWS.CreditCardWS();
        if (obj.CheckCard(CreditNumTxt.Text, CVVTxt.Text, FirstTxt.Text, LastTxt.Text, TypeDDL.SelectedItem.Text, MonthTxt.Text, YearTxt.Text))//האם פרטי הכרטיס נכונים
        {
            if (obj.ChargeTotalPrice(CreditNumTxt.Text, int.Parse(Session["TPrice"].ToString())))//אם לכרטיס יש מספיק כסף לבצע את הרכישה
            {
                String query = "insert into Purchases(PurchaseID,Username,PurchaseDate,PurchasePrice) values('" + OrderIdLbl.Text + "','" + Session["username"].ToString() + "','" + OrderDateLbl.Text + "','" + Session["TPrice"].ToString() + "')";
                Connection Mycon = new Connection();
                OleDbConnection scon = new OleDbConnection(Mycon.GetConString());
                scon.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = query;
                cmd.Connection = scon;
                cmd.ExecuteNonQuery();
                scon.Close();
                Response.Redirect("~/CheckoutComplete.aspx");//העברה לדף סיום הרכישה
            }
            else ErorLbl.Text = "You don't have enough money to purchase those games";
        }
        else
            ErorLbl.Text = "One input or more is incorrect";

    }
}