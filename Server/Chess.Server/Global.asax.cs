namespace Chess.Server
{
    using Chess.Server.App_Start;
    using System.Web.Http;


    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DatabaseConfig.Initialize();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
