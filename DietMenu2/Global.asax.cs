
namespace DietMenu2
{
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using DietMenu2.Models;

    using Ninject;

    using NLog;

    public class MvcApplication : System.Web.HttpApplication
    {
        public static readonly Logger Log = LogManager.GetCurrentClassLogger();
        
        public static readonly IKernel DependencyKernel = new StandardKernel();

        protected void Application_Start()
        {
            DependencyKernel.Bind<IUser>().To<User>();
            DependencyKernel.Bind<IExample>().To<Example>();

            IUser der = DependencyKernel.Get<IUser>();
            IExample desr = DependencyKernel.Get<IExample>();


            Log.Info("Запуск сервера");
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
