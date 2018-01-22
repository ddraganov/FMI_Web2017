using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using WebApplication1.Controllers;
using WebApplication1.CrossDomain;
using WebApplication1.DataAccess;

namespace WebApplication1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // IoC
            var builder = new ContainerBuilder();
            
            builder.RegisterType<SnailRepository>().As<ISnailRepository>().SingleInstance();
            builder.RegisterType<GlobalErrorHandler>().AsWebApiExceptionFilterFor<ApiController>();

            // вече не го слагаме просто като атрибут а го регистрираме тук
           //builder.RegisterType<AuthenticationFilterAttribute>().AsWebApiActionFilterFor<SnailsController>().InstancePerRequest();

            // регистрация на Delegating handler
            builder.RegisterType<ExampleDelegatingHandler>().As<DelegatingHandler>().InstancePerRequest();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
   
            // register filter for method using attributes
            builder.RegisterWebApiFilterProvider(config);
            builder.RegisterType<AuthenticationFilterAttribute>().PropertiesAutowired();

            IContainer container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            //добавяне на Delegating handler в конфигурацията. За съжаление тук не може без new :(
            config.MessageHandlers.Add(new ExampleDelegatingHandler());

            config.Routes.MapHttpRoute(
                name: "StuffApi",
                routeTemplate: "opi/stuff",
                defaults: new { controller = "Snails", action = "Opi" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
