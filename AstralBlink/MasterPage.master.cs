using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["Admin"]!=null)//אם מנהל התחבר
        {
            AdminLink.Visible = true;
        }
        if (Session["Username"] == null)//אם המשתמש לא מחובר
        {
            LoginLink.Text = "Login";
            SignUpLink.Text = "Sign Up";
            SignUpLink.NavigateUrl = "~/Register.aspx";
            

        }
        else// אם מחובר
        {
            UsernameLbl.Text = "Hello " + Session["Username"].ToString();
            LoginLink.Text = "Logout";
            SignUpLink.Text = "Profile";
            SignUpLink.NavigateUrl = "~/User.aspx";
            ShowdownLink.Visible = true;
            UsernameLbl.Visible = true;
           
        }
        DataTable dt = new DataTable();
        dt = (DataTable)Session["buyitems"];
        if (dt != null)//אם יש פריטים בסל קניות
        {

            CartCountLbl.Text = dt.Rows.Count.ToString();
        }
        else
        {
            CartCountLbl.Text = "0";

        }
    }

    protected void LoginLink_Click(object sender, EventArgs e)//מעביר לדף התחברות אם לא מחובר ומתנתק אם כן
    {
        if (Session["Username"] == null)//כפתור התחברות
            Response.Redirect("~/Login.aspx");
        else//כפתור התנתקות
        {
            Session.Abandon();
            Response.Redirect("~/Store.aspx");
        }

    }


    protected void LogoImage_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Store.aspx");
    }
}
