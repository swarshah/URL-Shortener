using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    String connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='C:\Users\Swar\Documents\Visual Studio 2013\WebSites\UrlShortener\App_Data\Database.mdf';Integrated Security=True";
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int id = getid();
        shortLink.Text = id.ToString();
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
}