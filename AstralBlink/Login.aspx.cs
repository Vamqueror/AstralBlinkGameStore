using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void PasswordTxt_TextChanged(object sender, EventArgs e)
    {

    }

    protected void UsernameTxt_TextChanged(object sender, EventArgs e)
    {

    }

    protected void LoginTxt_TextChanged(object sender, EventArgs e)
    {

    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }

    protected void LoginBtn_Click(object sender, EventArgs e)//Checks if input is correct compared to the DB, if it does correct then check user type
    {
        UserService US = new UserService();
      
        Connection mycon = new Connection();
        OleDbConnection dbcon = new OleDbConnection(mycon.GetConString());
        OleDbCommand cmd = new OleDbCommand("SelectPassword", dbcon);
        cmd.CommandType = CommandType.StoredProcedure;
        OleDbDataReader reader = null;
        dbcon.Open();
        OleDbParameter objparam = new OleDbParameter("@Username", OleDbType.BSTR);
        objparam.Value = UsernameTxt.Text;
        cmd.Parameters.Add(objparam);
        reader = cmd.ExecuteReader();

        if (reader.Read())//אם שם משתמש נכון
        {
            if (reader["UserPassword"].ToString() == PasswordTxt.Text)//אם סיסמא נכונה
            {
                Session["Username"] = UsernameTxt.Text;
                if ((bool)US.RunSingleStoredQuery("SelectIsAdmin", UsernameTxt.Text, "Username"))//אם אדמין
                {
                    Session["Admin"] = true;
                    Cart SCart = new Cart(UsernameTxt.Text);
                    Session["buyitems"] = SCart.fillsavedCart();//מטעין את סל הקניות
                    Response.Redirect("Admin.aspx");
                }
                else//אם משתמש רגיל
                {
                    Cart SCart = new Cart(UsernameTxt.Text);
                    Session["buyitems"] = SCart.fillsavedCart();//מטעין את סל הקניות
                    Response.Redirect("User.aspx");
                }
            }
            else
                ErorLbl.Text = "Username or Password is incorrect";
        }
        else ErorLbl.Text = "Username or Password is incorrect";
        dbcon.Close();
    }
}