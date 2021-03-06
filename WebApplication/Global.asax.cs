﻿using System;
using System.Collections.Generic;
using System.Configuration;
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

            AutoMapper.Mapper.CreateMap<DAL.Utilisateur, WebApplication.Models.UserEditee>();
            AutoMapper.Mapper.CreateMap<WebApplication.Models.UserEditee, DAL.Utilisateur>();

            AutoMapper.Mapper.CreateMap<DAL.Facture, WebApplication.Models.FactureEditee>();
            AutoMapper.Mapper.CreateMap<WebApplication.Models.FactureEditee, DAL.Facture>();

            AutoMapper.Mapper.CreateMap<DAL.Location, WebApplication.Models.LocationEditee>();
            AutoMapper.Mapper.CreateMap<WebApplication.Models.LocationEditee, DAL.Location>();

            AutoMapper.Mapper.CreateMap<DAL.Categorie, WebApplication.Models.CategorieEditee>();
            AutoMapper.Mapper.CreateMap<WebApplication.Models.CategorieEditee, DAL.Categorie>();

            AutoMapper.Mapper.CreateMap<DAL.Genre, WebApplication.Models.GenreEditee>();
            AutoMapper.Mapper.CreateMap<WebApplication.Models.GenreEditee, DAL.Genre>();

            


        }

        protected void Application_BeginRequest()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
        }
    }
}
