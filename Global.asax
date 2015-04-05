<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

    void Application_BeginRequest(object sender, EventArgs e)
    {

        String query = HttpContext.Current.Request.Url.PathAndQuery.ToString();
        //String host = HttpContext.Current.Request.Url.Query.ToString();
        if (!query.Equals("/default.aspx") && !query.StartsWith("/__browserLink/requestData/") && !query.Equals("/"))
        {
            //System.Diagnostics.Debug.WriteLine(HttpContext.Current.Request.Url.PathAndQuery.ToString());
            //Response.Redirect("Default2.aspx");
            Response.Status = "301 Moved Permanently";
            Response.AddHeader("Location", "/Default2.aspx?id=" + query);
            System.Diagnostics.Debug.WriteLine(HttpContext.Current.Request.Url.PathAndQuery.ToString());
        }
    }
       
</script>
