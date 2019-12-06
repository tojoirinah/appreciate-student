using Appreciation.Manager.Api.App_Start;
using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository;
using Appreciation.Manager.Services;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using AutoMapper;
using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace Appreciation.Manager.Api.App_Data
{
    public class UnityBootStrapper
    {
        public static IUnityContainer Ioc
        {
            get { return _container; }

        }

        private static IUnityContainer _container;

        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            // mapping with automapper
            var mapper = MappingProfile.InitializeAutoMapper(typeof(Student), typeof(AddStudentRequest)).CreateMapper();
            container.RegisterInstance<IMapper>(mapper);

            var resolver = new UnityDependencyResolver(container);
            DependencyResolver.SetResolver(resolver);
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
            _container = container;
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
            //container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());


            container.RegisterAllTypes(typeof(ReadOnlyRepository<>), LifecycleKind.Scoped);
            container.RegisterAllTypes(typeof(Repository.Tests.ReadOnlyRepositoryTest<>), LifecycleKind.PerRequest);

            container.RegisterAllTypes(typeof(Service<>), LifecycleKind.Default);
        }
    }
}