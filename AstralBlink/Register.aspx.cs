using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Connection mycon = new Connection();
        OleDbConnection con = new OleDbConnection(mycon.GetConString());
        OleDbCommand cmd = new OleDbCommand("select country from countries", con);
        con.Open();
        CountryDDL.DataSource = cmd.ExecuteReader();
        CountryDDL.DataTextField = "Country";
        CountryDDL.DataValueField = "Country";
        CountryDDL.DataBind();
        //CountryDDL.Items.Insert(0, new ListItem("Select","0"));

    }



    protected void UsernameTxt_TextChanged(object sender, EventArgs e)
    {

    }

    protected void PasswordTxt_TextChanged(object sender, EventArgs e)
    {

    }

    protected void ConfirmTxt_TextChanged(object sender, EventArgs e)
    {

    }

    protected void FirstTxt_TextChanged(object sender, EventArgs e)
    {

    }

    protected void LastTxt_TextChanged(object sender, EventArgs e)
    {

    }

    protected void EmailTxt_TextChanged(object sender, EventArgs e)
    {

    }

    protected void CountryDDL_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void SignUpBtn_Click(object sender, EventArgs e)//if page is valid, create new user in DB
    {
        ValidationWS.Validation validate = new ValidationWS.Validation();
        if (validate.isEmail(EmailTxt.Text))
        {
            Connection mycon = new Connection();
            OleDbConnection dbcon = new OleDbConnection(mycon.GetConString());
            OleDbCommand cmd = new OleDbCommand("RegisterNewUser", dbcon);
            bool taken = false;//משתנה בקרה הבודק אם החיבור נכנס לשגיאה ~ אם השם משתמש תפוס והדבר עשוי לגרום לכפל ערכים במסד נתונים
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                dbcon.Open();
                OleDbParameter[] objparam = new OleDbParameter[6] { new OleDbParameter("@Username", OleDbType.BSTR), new OleDbParameter("@UserPassword", OleDbType.BSTR), new OleDbParameter("@FirstName", OleDbType.BSTR), new OleDbParameter("@LastName", OleDbType.BSTR), new OleDbParameter("@Email", OleDbType.BSTR), new OleDbParameter("@Country", OleDbType.BSTR) };//מערך כל הפרמטרים של המשתמש 
                objparam[0].Value = UsernameTxt.Text;
                objparam[1].Value = PasswordTxt.Text;
                objparam[2].Value = FirstTxt.Text;
                objparam[3].Value = LastTxt.Text;
                objparam[4].Value = EmailTxt.Text;
                objparam[5].Value = CountryDDL.SelectedItem.Text;
                cmd.Parameters.Add(objparam[0]);
                cmd.Parameters.Add(objparam[1]);
                cmd.Parameters.Add(objparam[2]);
                cmd.Parameters.Add(objparam[3]);
                cmd.Parameters.Add(objparam[4]);
                cmd.Parameters.Add(objparam[5]);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                TakenLbl.Visible = true;
                taken = true;
            }
            finally
            {
                dbcon.Close();

            }
            if (!taken)//אם שם משתמש לא תפוס
            {
                ShowdownWS.ShowdownWS New = new ShowdownWS.ShowdownWS();
                New.NewUser(UsernameTxt.Text);//הוספת המשתמש לשירות הרשת showdown
                Response.Redirect("login.aspx");//שליחת המשתמש לדף התחברות אחרי הרשמה
            }
        }
        else
            ErrorEmail.Text = "Incorrect Email";
    }
}