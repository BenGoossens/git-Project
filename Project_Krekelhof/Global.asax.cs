﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MySql.Data.Entity;
using Project_Krekelhof.Models.DAL;

namespace Project_Krekelhof
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var init = new KrekelschoolInitializer();
            Database.SetInitializer<KrekelschoolContext>(init);
            var ctx = new KrekelschoolContext();
            ctx.Database.Initialize(true);
            var bedrijven = ctx.Boeken.ToList();
        }
    }
}
