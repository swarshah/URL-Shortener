using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;
using System.Text;

public partial class _Default : System.Web.UI.Page
{
    private String connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='C:\Users\Swar\Documents\Visual Studio 2013\WebSites\UrlShortener\App_Data\Database.mdf';Integrated Security=True";
    private String ALPHABET = "123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int id = getid();
        //shortLink.Text = id.ToString();
        shortLink.Text = encodeInt(getid());
        //shortLink.Text = HttpContext.Current.Request.Url.ToString();
    }

    protected int getid()
    {
        using (SqlConnection cn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 Id FROM link ORDER BY Id DESC;", cn);
            cn.Open();
            int id = (int) cmd.ExecuteScalar();
            cn.Close();
            return id+1;
        }
    }

    protected String encodeInt(int num)
    {
        int length = ALPHABET.Length;
        StringBuilder sb = new StringBuilder();
        while (num > 0) { 
            sb.Insert(0, ALPHABET[num % length]);
            num = num / length;
        }
        return "http://"+
                HttpContext.Current.Request.Url.Host.ToString()+
                ":"+
                HttpContext.Current.Request.Url.Port.ToString()+
                "/"+
                sb.ToString();
    }
}