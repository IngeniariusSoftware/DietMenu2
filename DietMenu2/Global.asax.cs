
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
            Log.Info("Запуск сервера");
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
