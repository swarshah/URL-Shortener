using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;
using System.Text;
/// <summary>
/// Summary description for MyUtils
/// </summary>
public class MyUtils
{
    private static String connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='C:\Users\Swar\Documents\Visual Studio 2013\WebSites\UrlShortener\App_Data\Database.mdf';Integrated Security=True";
    private static String ALPHABET = "123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
	public MyUtils()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static int getid()
    {
        using (SqlConnection cn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 Id FROM link ORDER BY Id DESC;", cn);
            cn.Open();
            int id = (int)cmd.ExecuteScalar();
            cn.Close();
            return id + 1;
        }
    }

    public static String encodeInt(int num)
    {
        int length = ALPHABET.Length;
        StringBuilder sb = new StringBuilder();
        while (num > 0)
        {
            sb.Insert(0, ALPHABET[num % length]);
            num = num / length;
        }
        return "http://" +
                HttpContext.Current.Request.Url.Host.ToString() +
                ":" +
                HttpContext.Current.Request.Url.Port.ToString() +
                "/" +
                sb.ToString();
    }

    public static int insertInDb(int id, String shorturl, String longurl)
    {
        using (SqlConnection cn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO link(Id, longUrl, shortUrl) Values(@Id, @longUrl, @shortUrl)", cn);

            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@longUrl", longurl);
            cmd.Parameters.AddWithValue("@shortUrl", shorturl);
            cn.Open();
            int result = cmd.ExecuteNonQuery();
            cn.Close();
            return result;
        }
    }
}