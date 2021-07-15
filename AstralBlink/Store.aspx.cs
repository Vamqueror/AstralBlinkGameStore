using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Store : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UserService Details = new UserService();
            StoreDataList.DataSource = Details.FillTableStored("Games", "SelectGames");//מציג את המשחקים שבמסד הנתונים
            StoreDataList.DataBind();
        }
    }


    protected void StoreDataList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void StoreDataList_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "ViewDetails")
        {
            Response.Redirect("Details.aspx?id=" + e.CommandArgument.ToString());//שולח את המשתמש לדף הפרטים עם קוד המשחק
        }
    }



}