using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

/// <summary>
/// Summary description for Cart
/// </summary>
public class Cart
{
    private String username;

    public Cart(string username)
    {
        this.username = username;
    }
    public DataTable fillsavedCart()//יוצר טבלה בזיכרון על פי ערכי הסל של המשתמש השמורים במסד הנתונים
    {
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add("Count");
        dt.Columns.Add("GameImage");
        dt.Columns.Add("GameCode");
        dt.Columns.Add("GameNameEN");
        dt.Columns.Add("GamePrice");

        Connection Mycon = new Connection();
        OleDbConnection con = new OleDbConnection(Mycon.GetConString());
        String query = "select * from ShoppingCart where Username='" + username + "'";
        OleDbCommand cmd = new OleDbCommand();
        cmd.CommandText = query;
        cmd.Connection = con;
        OleDbDataAdapter da = new OleDbDataAdapter();

        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            int i = 0;
            int counter = ds.Tables[0].Rows.Count;
            while (i < counter)
            {
                dr = dt.NewRow();
                dr["Count"] = i + 1;
                dr["GameCode"] = ds.Tables[0].Rows[i]["GameCode"].ToString();
                dr["GameNameEN"] = ds.Tables[0].Rows[i]["GameNameEN"].ToString();
                dr["GameImage"] = ds.Tables[0].Rows[i]["GameImage"].ToString();
                dr["GamePrice"] = ds.Tables[0].Rows[i]["GamePrice"].ToString();
                dt.Rows.Add(dr);
                i = i + 1;
            }

        }
        else
        {
            return null;

        }
        return dt;

    }

    public void SaveCartDetails(String productid, String Productname, String productimage, String price)//מכניס למסד הנתונים ערך חדש לסל הקניות של המשתמש

    {
        String query = "insert into ShoppingCart(Username,GameCode,GameNameEN,GameImage,GamePrice) values('" + username + "','"+productid + "','"+ Productname + "','" + productimage + "','" + price +  "')";

        Connection Mycon = new Connection();
        OleDbConnection scon = new OleDbConnection(Mycon.GetConString());
        scon.Open();
        OleDbCommand cmd = new OleDbCommand();
        cmd.CommandText = query;
        cmd.Connection = scon;
        cmd.ExecuteNonQuery();
    }

    //public Int32 CheckRowCart()
    //{

    //    Connection Mycon = new Connection();
    //    OleDbConnection scon = new OleDbConnection(Mycon.GetConString());
    //    String myquery = "select * from ShoppingCart ";
    //    OleDbCommand cmd = new OleDbCommand();
    //    cmd.CommandText = myquery;
    //    cmd.Connection = scon;
    //    OleDbDataAdapter da = new OleDbDataAdapter();
    //    da.SelectCommand = cmd;
    //    DataSet ds = new DataSet();
    //    da.Fill(ds);
    //    Int32 RNumber;
    //    return RNumber = ds.Tables[0].Rows.Count;
    //}

    public void ClearSavedCart()//מוחק את כל ערכי הסל של המשתמש ממסד נתונים
    {
        Connection Mycon = new Connection();
        OleDbConnection scon = new OleDbConnection(Mycon.GetConString());
        String updatedata = "delete * from ShoppingCart where username='" + username + "'";

        scon.Open();
        OleDbCommand cmd = new OleDbCommand();
        cmd.CommandText = updatedata;
        cmd.Connection = scon;
        cmd.ExecuteNonQuery();

    }

    public DataTable BuildCart()//מחזיר טבלה עם עמודות לפרטי משחק
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Count");
        dt.Columns.Add("GameImage");
        dt.Columns.Add("GameCode");
        dt.Columns.Add("GameNameEN");
        dt.Columns.Add("GamePrice");
        return dt;
    }
}