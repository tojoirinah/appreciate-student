using Appreciation.Manager.Api.App_Data;
using Appreciation.Manager.Repository;
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

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Container = UnityBootStrapper.Initialise();
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            if (!IsRollback)
            {
                var unitOfWork = Container.Resolve<IUnitOfWork>();
                unitOfWork.CommitAsync();
                //var unitOfWork = UnitOfWorkUtils.GetCurrentUnitOfWork;
                //if(unitOfWork!=null)
                //    unitOfWork.CommitAsync();
                //UnitOfWorkUtils.DestroyUnitOfWork();
            }

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            // var unitOfWork = Container.Resolve<IUnitOfWork>();
            // unitOfWork.RollbackAsync();
            //UnitOfWorkUtils.DestroyUnitOfWork();
            IsRollback = true;
        }
    }
}
