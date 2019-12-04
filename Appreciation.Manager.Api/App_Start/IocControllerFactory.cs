using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Unity;

namespace Appreciation.Manager.Api.App_Start
{
    public class IocControllerFactory : DefaultControllerFactory
    {
        private readonly IUnityContainer unityContainer;

        public IocControllerFactory(IUnityContainer unityContainer)
        {
            this.unityContainer = unityContainer;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType != null)
                return this.unityContainer.Resolve(controllerType) as IController;

            return base.GetControllerInstance(requestContext, controllerType);
        }
    }
}