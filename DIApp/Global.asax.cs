using Autofac;
using Autofac.Integration.Mvc;
using DIApp.DataAccess;
using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DIApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Create the IoC configuration container
            var builder = new ContainerBuilder();
            
            // Register controllers from the current assembly
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Register EF6 data context
            var context = new NORTHWNDEntities();
            context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s, "EF");
            builder.RegisterInstance(context).As<NORTHWNDEntities>();

            // Register all Repository classes from all assemblies, tie them to their interfaces and set their lifetime to per request
            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .Where(t => t.Name.EndsWith("Facade"))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            var container = builder.Build();
            // Tell MVC to use our own dependency resolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
