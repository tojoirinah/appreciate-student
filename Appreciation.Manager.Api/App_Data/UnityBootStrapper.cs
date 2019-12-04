using Appreciation.Manager.Repository;
using Appreciation.Manager.Services;
using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace Appreciation.Manager.Api.App_Data
{
    public class UnityBootStrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();
            var resolver = new UnityDependencyResolver(container);
            DependencyResolver.SetResolver(resolver);
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
            return container;
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            RegisterTypes(container);
            return container;
        }

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {

            container.RegisterAllTypes(typeof(ReadOnlyRepository<>));
            container.RegisterAllTypes(typeof(Repository.Tests.ReadOnlyRepositoryTest<>));
            container.RegisterAllTypes(typeof(Service<>));
        }
    }
}