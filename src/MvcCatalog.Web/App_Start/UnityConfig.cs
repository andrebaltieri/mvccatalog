using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using MvcCatalog.Data.Contexts;
using MvcCatalog.Domain.Repositories;
using MvcCatalog.Data.Repositories;

namespace MvcCatalog.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<MvcCatalogDataContext, MvcCatalogDataContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}