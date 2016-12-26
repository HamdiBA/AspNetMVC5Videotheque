using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapper.Mapper.CreateMap<DAL.Article, WebApplication.Models.ArticleEditee>();
            AutoMapper.Mapper.CreateMap<WebApplication.Models.ArticleEditee, DAL.Article>();

            AutoMapper.Mapper.CreateMap<DAL.Client, WebApplication.Models.ClientEditee>();
            AutoMapper.Mapper.CreateMap<WebApplication.Models.ClientEditee, DAL.Client>();

            AutoMapper.Mapper.CreateMap<DAL.User, WebApplication.Models.UserEditee>();
            AutoMapper.Mapper.CreateMap<WebApplication.Models.UserEditee, DAL.User>();
        }
    }
}
