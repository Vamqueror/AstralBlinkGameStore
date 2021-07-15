using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;

public class Connection
{
    public Connection()
    {

    }
    public string GetConString()//פעולה שמחזירה מחרוזת חיבור 
                                // של המאגר מידע
    {
        string fileName = "CreditCardDB.mdb";
        string location = HttpContext.Current.Server.MapPath("~/App_Data/" + fileName);
        string connectionstring = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source =" + location;
        return connectionstring;
    }

    public object GetSingleQuery(string query)//run query using scalar method
    {
        OleDbConnection con = new OleDbConnection(GetConString());
        OleDbCommand cmd = new OleDbCommand(query, con);
        object x = null;
        try
        {
            con.Open();
            x = cmd.ExecuteScalar();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return x;
    }
    //public void Close()
    //{
    //    OleDbConnection y = new OleDbConnection(GetConString());
    //    y.Close();
    //}
}