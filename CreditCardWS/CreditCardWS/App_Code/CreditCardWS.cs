using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.OleDb;
using System.Data;

/// <summary>
/// Summary description for CreditCardWS
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class CreditCardWS : System.Web.Services.WebService
{

    public CreditCardWS()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public bool CheckCard(string cardNum,string CVV,string first,string last,string type,string month,string year)//checks if credit card info is true compared to DB
    {
        Connection mycon = new Connection();
        OleDbConnection con = new OleDbConnection(mycon.GetConString());
        string query = "Select * From CreditCard Where CreditCardNumber='" + cardNum + "'";
        bool Compare = false;
        OleDbCommand cmd = new OleDbCommand(query, con);
        try
        {
          
            con.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                
                if (cardNum == reader["CreditCardNumber"].ToString()&& reader["CVV"].ToString()==CVV && first== reader["FirstName"].ToString()&& last== reader["LastName"].ToString()&&type== reader["Type"].ToString()&& month== reader["MonthEXP"].ToString()&&year== reader["YearEXP"].ToString())
                {
                    Compare = true;
                }
            }
        }
        catch(Exception ex)
        {

        }
        finally
        {
            con.Close();
        }
        return Compare;

    }
    [WebMethod]
    public bool ChargeTotalPrice(string cardNum, int TPrice)//charges the estimated price from the client
    {
        Connection Mycon = new Connection();


        string checkBalance = "Select Balance From CreditCard Where CreditCardNumber = '" + cardNum + "'";
        if ((int)Mycon.GetSingleQuery(checkBalance) - TPrice >= 0)
        {

            OleDbConnection con = new OleDbConnection(Mycon.GetConString());
            OleDbCommand cmd = new OleDbCommand("UpdateBalance",con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            OleDbParameter CardParam = new OleDbParameter("@cardNum", OleDbType.BSTR);
            OleDbParameter PriceParam = new OleDbParameter("@TPrice", OleDbType.BSTR);
            CardParam.Value = cardNum;
            PriceParam.Value = TPrice;
            cmd.Parameters.Add(PriceParam);
            cmd.Parameters.Add(CardParam);
            cmd.ExecuteNonQuery();
            return true;
        }
        else
            return false;

    }

}
