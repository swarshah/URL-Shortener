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
        if (!MyUtils.matchUrl(url.Text))
        {
            Label1.Text = "Invalid URL";
            error.Visible = true;
        }
        else
        {
            int id = MyUtils.getid();
            String shortUrl = MyUtils.encodeInt(MyUtils.getid());
            int result = MyUtils.insertInDb(id, shortUrl, url.Text);
            if (result == 1)
            {
                shortLink.Text = shortUrl;
                if (error.Visible == true)
                {
                    error.Visible = false;
                }
                shortLink.Visible = true;
                linkdiv.Visible = true;
                shortLink.Attributes.Add("onclick","this.select();");
            }
            else
            {
                shortLink.Text = "Error";
            }
        }
    }

    
}