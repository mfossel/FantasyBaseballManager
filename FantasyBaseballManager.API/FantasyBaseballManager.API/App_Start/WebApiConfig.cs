using AutoMapper;
using FantasyBaseballManager.API.Domain;
using FantasyBaseballManager.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FantasyBaseballManager.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            //CORS
            var rules = new EnableCorsAttribute("*", "*", "*");

            config.EnableCors(rules);

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //SET API TO RETURN JSON INSTEAD OF XML
            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

            CreateMaps();

     
    }
        private static void CreateMaps()
        {
            Mapper.CreateMap<Hitter, HitterModel>();
            Mapper.CreateMap<League, LeagueModel>();
            Mapper.CreateMap<Pitcher, PitcherModel>();
            Mapper.CreateMap<Team, TeamModel>();
        }
    }
}
