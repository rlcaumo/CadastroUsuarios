using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace WEBAPI_Usuarios
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().FirstOrDefault();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Entities.Usuario, ViewModels.UsuarioDto>();
                cfg.CreateMap<Entities.DetalheUsuario, ViewModels.DetalheUsuarioDto>();
                cfg.CreateMap<Entities.Usuario, ViewModels.UsuarioCreationDto>();
                cfg.CreateMap<ViewModels.UsuarioCreationDto, Entities.Usuario>();
                cfg.CreateMap<ViewModels.UsuarioUpdateDto, Entities.Usuario>();
                cfg.CreateMap<Entities.Usuario, ViewModels.UsuarioUpdateDto>();


            });

        }
    }
}
