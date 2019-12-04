using Appreciation.Manager.Api.App_Data;
using Appreciation.Manager.Repository.Contracts;
using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;

namespace Appreciation.Manager.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private static IUnityContainer Container;
        private static bool IsRollback { get; set; } = false;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            // SwaggerConfig.Register();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Container = UnityBootStrapper.Initialise();

            //var factory = new IocControllerFactory(Container);
            //ControllerBuilder.Current.SetControllerFactory(factory);
        }

        protected void Application_BeginRequest()
        {
            //if (Request.Headers.AllKeys.Contains("Origin") && Request.HttpMethod == "OPTIONS")
            //{
            //    Response.Flush();
            //}
        }

        protected void Application_EndRequest()
        {
            if (!IsRollback)
            {
                var unitOfWork = Container.Resolve<IUnitOfWork>();
                unitOfWork.CommitAsync();
            }

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var unitOfWork = Container.Resolve<IUnitOfWork>();
            unitOfWork.RollbackAsync();
            IsRollback = true;
        }
    }
}
