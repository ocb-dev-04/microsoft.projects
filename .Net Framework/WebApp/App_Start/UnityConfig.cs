using Unity;
using Unity.WebApi;
using DomainDI.Interfaces;
using DomainDI.Repositories;

namespace WebApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<IProductRepository, ProductRepository>();

            var dependedy = new UnityDependencyResolver(container);
        }
    }
}