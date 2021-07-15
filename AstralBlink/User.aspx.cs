using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class User : System.Web.UI.Page
{
    public static string query2;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            query2 = "select * from Users where Username='" + Session["Username"].ToString() + "'";
            UserService Details = new UserService();
            OrdersGrid.DataSource = Details.FillTable("select PurchaseID,PurchaseDate,PurchasePrice from Purchases where Username='"+Session["Username"].ToString() + "'");
            OrdersGrid.DataBind();
            if (OrdersGrid.Rows.Count==0)
                NoOrdersLbl.Visible = true;
            UserGrid.DataSource = Details.FillTable(query2);
            UserGrid.DataBind();
        }

    }
    protected void UserGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)//מחיקת שורה
    {
        string ID = ((UserGrid.Rows[e.RowIndex].Cells[0])).Text;

        String sSQL = "Delete * FROM Users where Username='" + ID + "'";

        Connection C = new Connection();
        OleDbConnection con = new OleDbConnection(C.GetConString());
        con.Open();
        OleDbCommand cmd = new OleDbCommand(sSQL, con);
        cmd.ExecuteNonQuery();
        UserGrid.EditIndex = -1;
        con.Close();
        UserService userService = new UserService();
        UserGrid.DataSource = userService.FillTable(query2);
        UserGrid.DataBind();
    }



    protected void UserGrid_RowEditing(object sender, GridViewEditEventArgs e)//עריכת שורה
    {
        UserGrid.EditIndex = e.NewEditIndex;
        UserService US = new UserService();
        UserGrid.DataSource = US.FillTable(query2);
        UserGrid.DataBind();
    }

    protected void UserGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)//עדכון שורה
    {
        string Username = (UserGrid.Rows[e.RowIndex].Cells[0]).Text;
        string Password = ((TextBox)(UserGrid.Rows[e.RowIndex].Cells[1].Controls[0])).Text;
        string FirstName = ((TextBox)(UserGrid.Rows[e.RowIndex].Cells[2].Controls[0])).Text;
        string LastName = ((TextBox)(UserGrid.Rows[e.RowIndex].Cells[3].Controls[0])).Text;
        string Email = ((TextBox)(UserGrid.Rows[e.RowIndex].Cells[4].Controls[0])).Text;
        string Country = ((UserGrid.Rows[e.RowIndex].Cells[5])).Text;
        ValidationWS.Validation validate = new ValidationWS.Validation();
        if (validate.isEmail(Email)&& Password != "" && FirstName != "" && LastName!="")
        {

            String sSQL = "Update Users set UserPassword='" + Password + "', FirstName='" + FirstName + "', LastName='" + LastName + "', Email='" + Email + "', Country='" + Country + "' where Username='" + Username + "'";

            Connection C = new Connection();
            OleDbConnection con = new OleDbConnection(C.GetConString());
            con.Open();
            OleDbCommand cmd = new OleDbCommand(sSQL, con);
            cmd.ExecuteNonQuery();
            UserGrid.EditIndex = -1;
            con.Close();
            UserService u1 = new UserService();
            UserGrid.DataSource = u1.FillTable(query2);
            UserGrid.DataBind();
        }
        else
            ErorLbl.Visible = true;
    }

    protected void UserGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)//ביטול עריכה
    {
        UserGrid.EditIndex = -1;
        UserService US = new UserService();
        UserGrid.DataSource = US.FillTable(query2);
        UserGrid.DataBind();
    }
}