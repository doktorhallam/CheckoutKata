using System;
using System.Web;
using System.Web.Http;

namespace CheckoutKata.Web.Service
{
    public class Global : HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            DependencyConfig.RegisterDependencies();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var origin = Request.Headers["Origin"];

            if(origin != null)
                Response.AddHeader("Access-Control-Allow-Origin", origin);

            Response.AddHeader("Access-Control-Allow-Methods", "*");
            Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, X-Requested-With");
            Response.AddHeader("Allow", "*");
        }

    }
}
