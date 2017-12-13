using System.Web.Http;
using Snails.Data;

namespace WebApplication1
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var migrator = (IDbMigrator)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IDbMigrator));
            migrator.Migrate();
        }
    }
}
