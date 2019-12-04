using Appreciation.Manager.Utils;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Appreciation.Manager.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuration et services API Web
            if (!string.IsNullOrEmpty(Settings.CorsDomain))
            {
                var cors = new EnableCorsAttribute(Settings.CorsDomain, "*", "*");
                config.EnableCors(cors);
            }
          

            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
