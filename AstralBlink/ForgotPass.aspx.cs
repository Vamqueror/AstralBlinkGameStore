using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Net;
using System.Net.Mail; 

public partial class ForgotPass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void SubmitBtn_Click(object sender, EventArgs e)
    {
        Connection mycon = new Connection();
        OleDbConnection dbcon = new OleDbConnection(mycon.GetConString());
        OleDbCommand cmd = new OleDbCommand("ForgotPass", dbcon);
        cmd.CommandType = CommandType.StoredProcedure;
        OleDbDataReader reader = null;

        dbcon.Open();
        OleDbParameter objparam = new OleDbParameter("@Email", OleDbType.BSTR);
        objparam.Value = EmailTxt.Text;
        cmd.Parameters.Add(objparam);
        reader = cmd.ExecuteReader();

        if (reader.Read())//אם המייל שייך לאחד המשתמשים
        {
            string password = reader["UserPassword"].ToString();
            string username = reader["Username"].ToString();
            string email = reader["Email"].ToString();


            MailMessage msg = new MailMessage("AstralBlinkGames@gmail.com", EmailTxt.Text);//new mail message
            msg.Subject = "Password Requested for your Astral Blink account";
            msg.Body = string.Format("Hello! {0} <h1></h1><br/> Your password is: <h1>{1}</h1><br/> Thanks, Astral Blink Team", username, password);//Email message Html code
            msg.IsBodyHtml = true;
            SmtpClient stmp = new SmtpClient();//creates new mail transfer protocol
            stmp.Host = "smtp.gmail.com";
            stmp.EnableSsl = true;//enables ssl security protocol
            NetworkCredential nc = new NetworkCredential();//Provides credentials for password-based authentication schemes
            nc.UserName = "AstralBlinkGames@gmail.com";
            nc.Password = "AstralBlinkGames40";
            stmp.UseDefaultCredentials = true;
            stmp.Credentials = nc;
            stmp.Port = 587;//gmail port
            stmp.Send(msg);
            ErorLbl.ForeColor = Color.Lime;
            ErorLbl.Text = "Your password has been sent to your email: " + EmailTxt.Text;

        }
        else
            ErorLbl.Text = "Unknown Email, Please try again";
    }
}