using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

public partial class Showdown : System.Web.UI.Page
{
    public static int PlayerSum;//סכום ערכי קלפי השחקן
    protected void Page_Load(object sender, EventArgs e)
    {
        ShowdownWS.ShowdownWS game = new ShowdownWS.ShowdownWS();
        if (!game.CanPlay(Session["Username"].ToString()))//אם למשתמש אין משחקים שלא מומשו - לא יכול לשחק
        {
            Response.Redirect("~/ShowdownTutorial.aspx");
        }

    }

    protected void StartBtn_Click(object sender, EventArgs e)//מתחיל משחק Showdown
    {
        ShowdownWS.ShowdownWS game = new ShowdownWS.ShowdownWS();
        PlayerSum = 0;
        object[] playerArr = game.NewGame(Session["Username"].ToString());

        for(int i=0;i<6;i+=2)//סכימת ערכי יד השחקן
        {
           PlayerSum += int.Parse(playerArr[i].ToString());
        }
        AiCardLeft.ImageUrl = "/images-Showdown/CardBack.png";//החזרת הקלפים למצב המקורי למקרה שזה לא משחק ראשון
        AiCardMid.ImageUrl = "/images-Showdown/CardBack.png";
        AiCardRight.ImageUrl = "/images-Showdown/CardBack.png";
        PlayerCardRight.ImageUrl = playerArr[1].ToString();
        PlayerCardMid.ImageUrl = playerArr[3].ToString();
        PlayerCardLeft.ImageUrl = playerArr[5].ToString();
        StrongerBtn.Visible = true;
        WeakerBtn.Visible = true;
        YourCardsLbl.Visible = true;
        ResultLbl.Text = "";
    }

    protected void StrongerBtn_Click(object sender, EventArgs e)//להמר על פי היד החזקה יותר
    {
        ShowdownWS.ShowdownWS game = new ShowdownWS.ShowdownWS();
        object[] results = game.WinByStronger(PlayerSum,Session["Username"].ToString());
        AiCardLeft.ImageUrl = results[0].ToString();
        AiCardMid.ImageUrl = results[1].ToString();
        AiCardRight.ImageUrl = results[2].ToString();
        ResultLbl.Visible = true;
        if ((bool)results[3])//אם ניצח
        {
            ResultLbl.Text = "YOU WIN!!!";
        }
        else
            ResultLbl.Text = "You Lost ;-;";
        WeakerBtn.Visible = false;
        StrongerBtn.Visible = false;

    }

    protected void WeakerBtn_Click(object sender, EventArgs e)//להמר על פי היד החלשה יותר
    {
        ShowdownWS.ShowdownWS game = new ShowdownWS.ShowdownWS();
        object[] results = game.WinByWeaker(PlayerSum,Session["Username"].ToString());
        AiCardLeft.ImageUrl = results[0].ToString();
        AiCardMid.ImageUrl = results[1].ToString();
        AiCardRight.ImageUrl = results[2].ToString();
        ResultLbl.Visible = true;
        if ((bool)results[3])//אם ניצח
        {
            ResultLbl.Text = "YOU WIN!!!";
        }
        else
            ResultLbl.Text = "You Lost ;-;";
        WeakerBtn.Visible = false;
        StrongerBtn.Visible = false;
    }
}