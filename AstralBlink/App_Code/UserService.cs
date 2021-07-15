using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

/// <summary>
/// Summary description for UserService
/// </summary>
public class UserService
{
    public UserService()
    {
        //
        // TODO: Add constructor logic here
        //
    }
   public object RunSingleStoredQuery(string QueryName, string value,string con)//run stored query and return value using scalar method
    {
        Connection mycon = new Connection();
        OleDbConnection dbcon = new OleDbConnection(mycon.GetConString());
        OleDbCommand cmd = new OleDbCommand(QueryName, dbcon);
        cmd.CommandType = CommandType.StoredProcedure;
        object x = null;
        try
        {
            dbcon.Open();
            OleDbParameter objparam = new OleDbParameter("@" + con, OleDbType.BSTR);
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

    public object RunSingleQuery(string query)//run query using scalar method
    {
        Connection mycon = new Connection();
        OleDbConnection con = new OleDbConnection(mycon.GetConString());
        OleDbCommand cmd = new OleDbCommand(query, con);
        object x = null;
        try
        {
            con.Open();
            x = cmd.ExecuteScalar();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return x;
    }
    public OleDbDataReader ReadStoredQuery(string QueryName, string value, string con)//run stored query and return reader
    {
        Connection mycon = new Connection();
        OleDbConnection dbcon = new OleDbConnection(mycon.GetConString());
        OleDbCommand cmd = new OleDbCommand(QueryName, dbcon);
        cmd.CommandType = CommandType.StoredProcedure;
        OleDbDataReader reader = null;
        try
        {
            dbcon.Open();
            OleDbParameter objparam = new OleDbParameter("@" + con, OleDbType.BSTR);
            objparam.Value = value;
            cmd.Parameters.Add(objparam);
            reader = cmd.ExecuteReader();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
        }
        finally
        {
            dbcon.Close();
        }

        return reader;
    }
    public DataSet FillTableStored(String tblName,string query)//fills Dataset using stored query
    {
        Connection con = new Connection();
        OleDbConnection connect = new OleDbConnection(con.GetConString());
        OleDbCommand CMD = new OleDbCommand(query,connect);
        CMD.CommandType = CommandType.StoredProcedure;
        OleDbDataAdapter DA = new OleDbDataAdapter(CMD);
        DataSet DS = new DataSet();
        DA.Fill(DS,tblName);
        return DS;
    }
    public DataSet FillTable(string query)//fills Dataset using query
    {
        Connection con = new Connection();
        OleDbConnection connect = new OleDbConnection(con.GetConString());
        OleDbCommand CMD = new OleDbCommand(query, connect);
        OleDbDataAdapter DA = new OleDbDataAdapter(CMD);
        DataSet DS = new DataSet();
        DA.Fill(DS);
        return DS;
    }
    //public DataSet TblSelect(string tbl,string column,string condition)//fills Dataset using query with condition
    //{
    //    Connection con = new Connection();
    //    OleDbConnection connect = new OleDbConnection(con.GetConString());
    //    string query = " select * from '"+tbl+"' where '"+column+"'='" + condition + "'";
    //    OleDbDataAdapter DA = new OleDbDataAdapter(query, connect);
    //    DataSet DS = new DataSet();

    //    DA.Fill(DS, tbl+","+condition);
    //    return DS;
    //}
}