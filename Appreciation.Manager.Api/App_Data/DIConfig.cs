using System;
using System.Linq;
using System.Reflection;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Lifetime;

namespace Appreciation.Manager.Api.App_Data
{
    public static class DIConfig
    {
        public static void RegisterAllTypes(this IUnityContainer container, Type type, LifecycleKind lifecycle)
        {
            foreach (Type impl in Assembly.GetAssembly(type).GetTypes().Where(x => x.IsClass && !x.IsAbstract && !x.IsGenericType))
            {
                Type intf = impl.GetInterface("I" + impl.Name);
                if (intf != null)
                {
                    var cycle = GetLifetimeManager(lifecycle);
                    if (cycle != null)
                        container.RegisterType(intf, impl, cycle);
                    else
                        container.RegisterType(intf, impl);

                }

            }

        }

        private static ITypeLifetimeManager GetLifetimeManager(LifecycleKind lifecycle)
        {
            switch (lifecycle)
            {
                case LifecycleKind.Singleton:
                    return new ContainerControlledLifetimeManager();
                case LifecycleKind.PerRequest:
                    return new PerRequestLifetimeManager();
                case LifecycleKind.Scoped:
                    return new HierarchicalLifetimeManager();
                case LifecycleKind.Transient:
                    return new TransientLifetimeManager();
                case LifecycleKind.Default:
                    return null;
                default:
                    throw new NotSupportedException(lifecycle.ToString());
            }
        }
    }
}