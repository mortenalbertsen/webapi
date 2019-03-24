using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BookApp.Repository;
using BookApp.Services;
using Unity;
using Unity.AspNet.Mvc;
using UnityDependencyResolver = BookApp.Unity.UnityDependencyResolver;

namespace BookApp {
    public class WebApiApplication : System.Web.HttpApplication {
        private static IUnityContainer _container;

        private static IUnityContainer CreateUnityContainer() {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        }

        private static void RegisterTypes(UnityContainer unityContainer) {

            unityContainer.RegisterType<IUserService, UserService>();
            unityContainer.RegisterType<IBookService, BookService>();

            unityContainer.RegisterType<BaseDBContext>(new PerRequestLifetimeManager());
            unityContainer.RegisterType<IUserRepository, UserRepository>();
            unityContainer.RegisterType<IBookRepository, BookRepository>();
            
        }

        private static void RegisterIoC() {
            if (_container == null) {
                _container = CreateUnityContainer();
            }
        }

        protected void Application_Start() {
            RegisterIoC();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(_container);
            var formatters = System.Web.Http.GlobalConfiguration.Configuration.Formatters;
            var appXmlType = formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

        }
    }
}
