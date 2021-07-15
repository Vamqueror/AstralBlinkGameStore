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
        string fileName = "AstralBlinkDB.mdb";
        string location = HttpContext.Current.Server.MapPath("~/App_Data/" + fileName);
        string connectionstring = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source =" + location;
        return connectionstring;
    }

    //public void Close()// closes connection with DB
    //{
    //    OleDbConnection y = new OleDbConnection(GetConString());
    //    y.Close();
    //}
}