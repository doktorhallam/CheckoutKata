using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using CheckoutKata.Business.Providers;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

namespace CheckoutKata.Web.Service
{
    public static class DependencyConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            // Provider registration
            builder
                .Register(
                b => new ProductProvider())
                .AsSelf();

            builder
                .Register(
                b => new CartProvider())
                .SingleInstance()
                .AsSelf();

            // Controller registration
            builder
                .RegisterApiControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); // Mvc Resolver
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container); // WebApi Resolver
        }
    }
}
