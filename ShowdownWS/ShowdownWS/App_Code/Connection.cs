using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;

public class Connection
{
    public Connection()
    {

    }
    public string GetConString()//פעולה שמחזירה מחרוזת חיבור 
                                // של המאגר מידע
    {
        string fileName = "ShowdownDB.mdb";
        string location = HttpContext.Current.Server.MapPath("~/App_Data/" + fileName);
        string connectionstring = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source =" + location;
        return connectionstring;
    }

    public void Close()// closes connection with DB
    {
        OleDbConnection y = new OleDbConnection(GetConString());
        y.Close();
    }

    public OleDbDataReader ReadTable (string query)//gets query string and returns a an OleDbreader
    {
        Connection mycon = new Connection();
        OleDbConnection con = new OleDbConnection(mycon.GetConString());
        OleDbDataReader reader = null;
        OleDbCommand cmd = new OleDbCommand(query, con);
        try
        {
            con.Open();
            reader = cmd.ExecuteReader();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return reader;

    }
    public void RunStoredQuery(string QueryName, string value)//executing stored query 
    {
        Connection mycon = new Connection();
        OleDbConnection dbcon = new OleDbConnection(mycon.GetConString());
        OleDbCommand cmd = new OleDbCommand(QueryName, dbcon);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            dbcon.Open();
            OleDbParameter objparam = new OleDbParameter("@Username", OleDbType.BSTR);
            objparam.Value = value;
            cmd.Parameters.Add(objparam);
            cmd.ExecuteScalar();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
        }
        finally
        {
            dbcon.Close();
        }

    }
    public object RunSingleStoredQuery(string QueryName, string value)//run stored query using scalar method when the value given is an username
    {
        Connection mycon = new Connection();
        OleDbConnection dbcon = new OleDbConnection(mycon.GetConString());
        OleDbCommand cmd = new OleDbCommand(QueryName, dbcon);
        cmd.CommandType = CommandType.StoredProcedure;
        object x = null;
        try
        {
            dbcon.Open();
            OleDbParameter objparam = new OleDbParameter("@Username", OleDbType.BSTR);
            objparam.Value = value;
            cmd.Parameters.Add(objparam);
            x = cmd.ExecuteScalar();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
        }
        finally
        {
            dbcon.Close();
        }

        return x;
    }
}