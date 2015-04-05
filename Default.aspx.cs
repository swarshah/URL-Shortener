using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int id = MyUtils.getid();

        String shortUrl = MyUtils.encodeInt(MyUtils.getid());
        int result = MyUtils.insertInDb(id, shortUrl, url.Text);
        if (result == 1)
        {
            shortLink.Text = shortUrl;
        }
        else
        {
            shortLink.Text = "Error";
        }
        shortLink.Visible = true; 
    }

    
}