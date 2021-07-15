using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;

public partial class AddGame : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UserService u1 = new UserService();
            GamesGrid.DataSource = u1.FillTable("Select * from Games");//מציג את כל המשחקים
            GamesGrid.DataBind();
        }
    }

    protected void AddGameBtn_Click(object sender, EventArgs e)//מוסיף משחק חדש לבסיס נתונים על פי נתונים שהוזנו
    {
        Connection con = new Connection();
        UserService u1 = new UserService();
        OleDbConnection dbcon = new OleDbConnection(con.GetConString());
        string query = "Select * from Games";
        OleDbDataAdapter DA = new OleDbDataAdapter(query, dbcon);
        DataSet DS = new DataSet();
        try
        {
            DA.Fill(DS, "game");
            DataRow NewRow = DS.Tables["game"].NewRow();//יצירת שורה חדשה עם ערכי המשחק שהוזנו
            NewRow[1] = NameTxt.Text;
            NewRow[2] = GenreTxt.Text;
            NewRow[3] = YearTxt.Text;
            NewRow[4] = PriceTxt.Text;
            NewRow[5] = "/images-Games/" + ImageTxt.Text;
            NewRow[6] = SummaryTxt;
            DS.Tables["game"].Rows.Add(NewRow);
            OleDbCommandBuilder builder = new OleDbCommandBuilder(DA);
            DA.InsertCommand = builder.GetInsertCommand();
            DA.Update(DS, "game");
            GamesGrid.DataSource = u1.FillTable(query);
            GamesGrid.DataBind();
        }
        catch (Exception ex)
        {

        }
        finally
        {

        }
    }

    protected void GamesGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GamesGrid.PageIndex = e.NewPageIndex;
        UserService u1 = new UserService();
        GamesGrid.DataSource = u1.FillTable("select * from Games");
        GamesGrid.DataBind();
    }
}