using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using YudianBlog.Infrastructure.Configuration;

namespace YudianBlog.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            BootStrapper.SetControllerFactory();
            //设置IOC
            BootStrapper.ConfigureDependencies();

            ApplicationSettingsFactory.InitializeApplicationSettingsFactory(new WebConfigApplicationSettings());
            IApplicationSettings app = ApplicationSettingsFactory.GetApplicationSettings();

            YudianBlog.Services.AutoMapperBootStrapper.ConfigureAutoMapper();

            AreaRegistration.RegisterAllAreas();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
