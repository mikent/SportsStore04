using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Vic.SportsStore.Domain.Entities;
using Vic.SportsStore.WebApp.Infrastructure.Binders;

namespace Vic.SportsStore.WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
			IocConfig.ConfigIoc();
			ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
		}
    }
}
