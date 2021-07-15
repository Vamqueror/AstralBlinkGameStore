using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.OleDb;

/// <summary>
/// Summary description for ShowdownWS
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class ShowdownWS : System.Web.Services.WebService
{

    public ShowdownWS()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public Object[] NewGame(string Username)//creates new hand for the player
    {
        Connection con = new Connection();
        con.RunStoredQuery("Start", Username);//updates DB (subtract games for user by 1)
        return NewHand();
    }



    [WebMethod]
    public Object[] WinByStronger(int playerSum,String Username)//gets the player's hand and returns the bots hand & true if the player won by stronger cards
    {
        object[] botHand = NewHand();
        object[] win = new object[4];
        int botSum = 0, j = 0;
        for (int i = 0; i < 6; i += 2)
        {
            botSum += int.Parse(botHand[i].ToString());
            win[j] = botHand[i+1];
            j++;
        }
        if (playerSum > botSum)
        {
            win[3] = true;
            Connection con = new Connection();
            con.RunStoredQuery("Win", Username);
            return win;
        }
        else
        {
            win[3] = false;
            return win;
        }
    }

    [WebMethod]
    public Object[] WinByWeaker(int playerSum,string Username)//gets the player's hand and returns the bots hand & true if the player won by weaker cards
    {
        object[] botHand = NewHand();
        object[] win = new object[4];
        int botSum = 0, j = 0;
        for (int i = 0; i < 6; i += 2)
        {
            botSum += int.Parse(botHand[i].ToString());
            win[j] = botHand[i + 1];
            j++;
        }
        if (playerSum < botSum)
        {
            win[3] = true;
            Connection con = new Connection();
            con.RunStoredQuery("Win", Username);
            return win;
        }
        else
        {
            win[3] = false;
            return win;
        }

    }

    [WebMethod]
    public bool CanPlay(string Username)//check if user is able to play Showdown game
    {
        Connection con = new Connection();
        return (int.Parse(con.RunSingleStoredQuery("GetEigible", Username).ToString()) > 0);
    }


    [WebMethod]
    public void AddGames(string username,int games)//add X reedemable showdown games to user
    {
        Connection mycon = new Connection();
        OleDbConnection dbcon = new OleDbConnection(mycon.GetConString());
        OleDbCommand cmd = new OleDbCommand("AddEligible", dbcon);
        cmd.CommandType = CommandType.StoredProcedure;
            dbcon.Open();
            OleDbParameter objparam2 = new OleDbParameter("@GamesEligible", OleDbType.BSTR);
            objparam2.Value = games;
            cmd.Parameters.Add(objparam2);
            OleDbParameter objparam1 = new OleDbParameter("@Username", OleDbType.BSTR);
            objparam1.Value = username;
            cmd.Parameters.Add(objparam1);
            cmd.ExecuteScalar();

    }

    [WebMethod]
    public bool UseWin(string Username)//substract 1 win from the user
    {
        Connection con = new Connection();
        if (int.Parse(con.RunSingleStoredQuery("GetWon", Username).ToString()) > 0)
        {
            con.RunStoredQuery("UseWin", Username);
            return true;
        }
        return false;
    }
    [WebMethod]
    public void NewUser(string Username)//add new user to Showdown DB
    {
        Connection con = new Connection();
        con.RunStoredQuery("AddUser", Username);
        
    }

    public object[] NewHand()//returns object array with card values on the first line and card urls on the second
    {
        int[] cardId = RandomCardID();
        object[] Hand = new object[6];
        OleDbDataReader reader;
        int j = 0;

        for (int i = 0; i < 6; i+=2)
        {
            Connection con = new Connection();
            OleDbConnection dbcon = new OleDbConnection(con.GetConString());
            OleDbCommand cmd = new OleDbCommand("Select * From Cards Where CardID=" + cardId[j] + "", dbcon);
            
          
            try
            {
                dbcon.Open();
                reader = cmd.ExecuteReader();
                if(reader.HasRows)
                while (reader.Read())
                {
                    Hand[i] = reader["CardValue"].ToString();
                    Hand[i+1] = reader["CardUrl"].ToString();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                dbcon.Close();
            }
            j++;
        }
        return Hand;
    }

    public int[] RandomCardID()// generate 3 random numbers from 1 to 9 and returns them
    {
        int[] arr = new int[3];
        Random rng = new Random();
        for (int i = 0; i < 3; i++)
        {
            arr[i] = rng.Next(1, 10);
        }
        return arr;
    }
}
