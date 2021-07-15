using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ShowdownTutorial : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ShowdownWS.ShowdownWS game = new ShowdownWS.ShowdownWS();
        if (!game.CanPlay(Session["Username"].ToString()))//אם לא יכול לשחק
        {
            CanPlayLbl.Text = "You aren't eligible to play the game";
            CanPlayLbl.Visible = true;
            ShowdownLink.Visible = false;
        }
    }
}