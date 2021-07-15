using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Drawing;

public partial class Admin : System.Web.UI.Page
{
    public string query = "select * from Games";//select all games from DB
    public string query2 = "Select * from Users";//select all users from DB
    public string query3 = "Select * from Countries";//select all countires from DB
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UserService u1 = new UserService();
            GameDetailsGrid.DataSource = u1.FillTable(query);
            GameDetailsGrid.DataBind();
            UserGrid.DataSource = u1.FillTable(query2);
            UserGrid.DataBind();
            CountryGrid.DataSource = u1.FillTable(query3);
            CountryGrid.DataBind();
        }
    }
    protected void GameDetailsGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)//מחיקת שורה
    {
        string ID = ((GameDetailsGrid.Rows[e.RowIndex].Cells[0])).Text;

        String sSQL = "Delete * FROM Games where GameCode=" + ID + "";

        Connection C = new Connection();
        OleDbConnection con = new OleDbConnection(C.GetConString());
        con.Open();
        OleDbCommand cmd = new OleDbCommand(sSQL, con);
        cmd.ExecuteNonQuery();
        GameDetailsGrid.EditIndex = -1;
        con.Close();
        UserService userService = new UserService();
        GameDetailsGrid.DataSource = userService.FillTable(query);
        GameDetailsGrid.DataBind();

    }

    protected void GameDetailsGrid_RowEditing(object sender, GridViewEditEventArgs e)//עריכת שורה
    {
        GameDetailsGrid.EditIndex = e.NewEditIndex;
        UserService US = new UserService();
        GameDetailsGrid.DataSource = US.FillTable(query);
        GameDetailsGrid.DataBind();
        GameDetailsGrid.EditRowStyle.BackColor = Color.Crimson;
    }

    protected void GameDetailsGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)//ביטול עריכה
    {
        GameDetailsGrid.EditIndex = -1;
        UserService US = new UserService();
        GameDetailsGrid.DataSource = US.FillTable(query);
        GameDetailsGrid.DataBind();
    }

    protected void GameDetailsGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)//עדכון שורה
    {
        string GameCode = ((GameDetailsGrid.Rows[e.RowIndex].Cells[0])).Text;
        string GameName = ((TextBox)(GameDetailsGrid.Rows[e.RowIndex].Cells[1].Controls[0])).Text;
        string GameGenre = ((TextBox)(GameDetailsGrid.Rows[e.RowIndex].Cells[2].Controls[0])).Text;
        string GameYear = ((TextBox)(GameDetailsGrid.Rows[e.RowIndex].Cells[3].Controls[0])).Text;
        string GamePrice = ((TextBox)(GameDetailsGrid.Rows[e.RowIndex].Cells[4].Controls[0])).Text;
        string GameImage = ((TextBox)(GameDetailsGrid.Rows[e.RowIndex].Cells[5].Controls[0])).Text;
        if (GamePrice != "" && GameName != "" && IsDigitsOnly(GamePrice))
        {
            String sSQL = "Update Games set GameNameEN='" + GameName + "', GameGenre='" + GameGenre + "', GameYear=" + GameYear + ", GamePrice=" + GamePrice + ", GameImage='" + GameImage + "' where GameCode=" + GameCode + "";

            Connection C = new Connection();
            OleDbConnection con = new OleDbConnection(C.GetConString());
            con.Open();
            OleDbCommand cmd = new OleDbCommand(sSQL, con);
            cmd.ExecuteNonQuery();
            GameDetailsGrid.EditIndex = -1;
            con.Close();
            UserService u1 = new UserService();
            GameDetailsGrid.DataSource = u1.FillTable(query);
            GameDetailsGrid.DataBind();
            ErorLbl2.Visible = false;
        }
        else
            ErorLbl2.Visible = true;
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
        UserGrid.EditRowStyle.BackColor = Color.Crimson;
    }

    protected void UserGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)//עדכון שורה
    {
        string Username = (UserGrid.Rows[e.RowIndex].Cells[0]).Text;
        string Password = ((TextBox)(UserGrid.Rows[e.RowIndex].Cells[1].Controls[0])).Text;
        string FirstName = ((TextBox)(UserGrid.Rows[e.RowIndex].Cells[2].Controls[0])).Text;
        string LastName = ((TextBox)(UserGrid.Rows[e.RowIndex].Cells[3].Controls[0])).Text;
        string Email = ((TextBox)(UserGrid.Rows[e.RowIndex].Cells[4].Controls[0])).Text;
        string Country = ((TextBox)(UserGrid.Rows[e.RowIndex].Cells[5].Controls[0])).Text;
        string IsAdmin;
        if (((CheckBox)(UserGrid.Rows[e.RowIndex].Cells[6].Controls[0])).Checked)
            IsAdmin = "1";
        else
            IsAdmin = "0";
        ValidationWS.Validation validate = new ValidationWS.Validation();
        if (validate.isEmail(Email) && Password != "" && FirstName != "" && LastName != "")
        {

            String sSQL = "Update Users set UserPassword='" + Password + "', FirstName='" + FirstName + "', LastName='" + LastName + "', Email='" + Email + "', Country='" + Country + "', IsAdmin = '" + IsAdmin + "' where Username='" + Username + "'";

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
            ErorLbl.Visible = false;
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

    protected void GameDetailsGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)//פונקציית העברת דפים בטבלת משחקים
    {
        GameDetailsGrid.PageIndex = e.NewPageIndex;
        UserService u1 = new UserService();
        GameDetailsGrid.DataSource = u1.FillTable(query);
        GameDetailsGrid.DataBind();
    }

    protected void GameDetailsGrid_PreRender(object sender, EventArgs e)
    {

    }

    protected void UserGrid_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

    }

    protected void UserGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)//פונקציית העברת דפים בטבלת משתמשים
    {
        UserGrid.PageIndex = e.NewPageIndex;
        UserService u1 = new UserService();
        UserGrid.DataSource = u1.FillTable(query2);
        UserGrid.DataBind();
    }


    protected void CountryGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string Country = ((CountryGrid.Rows[e.RowIndex].Cells[0])).Text;
        string Currency = ((TextBox)(CountryGrid.Rows[e.RowIndex].Cells[1].Controls[0])).Text;

        String sSQL = "Update Countries set CCurrency='" + Currency + "' where Country='"+Country+"'";

        Connection C = new Connection();
        OleDbConnection con = new OleDbConnection(C.GetConString());
        con.Open();
        OleDbCommand cmd = new OleDbCommand(sSQL, con);
        cmd.ExecuteNonQuery();
        CountryGrid.EditIndex = -1;
        con.Close();
        UserService u1 = new UserService();
        CountryGrid.DataSource = u1.FillTable(query3);
        CountryGrid.DataBind();
    }

    protected void CountryGrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        CountryGrid.EditIndex = e.NewEditIndex;
        UserService US = new UserService();
        CountryGrid.DataSource = US.FillTable(query3);
        CountryGrid.DataBind();
        CountryGrid.EditRowStyle.BackColor = Color.Crimson;
    }

    protected void CountryGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string Country = ((CountryGrid.Rows[e.RowIndex].Cells[0])).Text;

        String sSQL = "Delete * FROM Countries where Country='" + Country + "'";

        Connection C = new Connection();
        OleDbConnection con = new OleDbConnection(C.GetConString());
        con.Open();
        OleDbCommand cmd = new OleDbCommand(sSQL, con);
        cmd.ExecuteNonQuery();
        CountryGrid.EditIndex = -1;
        con.Close();
        UserService userService = new UserService();
        CountryGrid.DataSource = userService.FillTable(query3);
        CountryGrid.DataBind();
    }

    protected void CountryGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        CountryGrid.EditIndex = -1;
        UserService US = new UserService();
        CountryGrid.DataSource = US.FillTable(query3);
        CountryGrid.DataBind();
    }

    protected void AddCountryBtn_Click(object sender, EventArgs e)
    {
        Connection con = new Connection();
        UserService u1 = new UserService();
        OleDbConnection dbcon = new OleDbConnection(con.GetConString());
        string query = "Select * from Countries";
        OleDbDataAdapter DA = new OleDbDataAdapter(query, dbcon);
        DataSet DS = new DataSet();
        try
        {
            DA.Fill(DS, "country");
            DataRow NewRow = DS.Tables["country"].NewRow();//יצירת שורה חדשה עם ערכי הארץ שהוזנו
            NewRow[0] = CountryTxt.Text;
            NewRow[1] = CurrencyTxt.Text;

            DS.Tables["country"].Rows.Add(NewRow);
            OleDbCommandBuilder builder = new OleDbCommandBuilder(DA);
            DA.InsertCommand = builder.GetInsertCommand();
            DA.Update(DS, "country");
            CountryGrid.DataSource = u1.FillTable(query3);
            CountryGrid.DataBind();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            
        }
        CountryTxt.Text = null;
        CurrencyTxt.Text = null;
    }

    public bool IsDigitsOnly(string str)//returns true if string contains only numbers
    {
        foreach (char c in str)
        {
            if (c < '0' || c > '9')
                return false;
        }

        return true;
    }
}