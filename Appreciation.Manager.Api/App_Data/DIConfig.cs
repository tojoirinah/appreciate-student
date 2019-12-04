using System;
using System.Linq;
using System.Reflection;
using Unity;

namespace Appreciation.Manager.Api.App_Data
{
    public static class DIConfig
    {
        public static void RegisterAllTypes(this IUnityContainer container, Type type)
        {
            foreach (Type impl in Assembly.GetAssembly(type).GetTypes().Where(x => x.IsClass && !x.IsAbstract && !x.IsGenericType))
            {
                Type intf = impl.GetInterface("I" + impl.Name);
                if (intf != null)
                    container.RegisterType(intf, impl);
            }

        }
    }
}