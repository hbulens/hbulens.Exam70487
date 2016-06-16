using Autofac;
using Autofac.Integration.WebApi;
using hbulens.Exam70487.Core;
using hbulens.Exam70487.Repositories;
using hbulens.Exam70487.WebApi.Formatters;
using Microsoft.Owin.Cors;
using Owin;
using System.Data.Entity;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace hbulens.Exam70487.WebApi
{
    public class Startup
    {
        /// <summary>
        /// This code configures Web API. 
        /// The Startup class is specified as a type parameter in the WebApp.Start method.
        /// </summary>
        /// <param name="appBuilder"></param>
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            appBuilder.UseCors(CorsOptions.AllowAll);
            appBuilder.UseWebApi(config);

            config.Formatters.Add(new CsvFormatter());
           

            // Dependency Injection
            ContainerBuilder builder = new ContainerBuilder();

            // Just register controllers and the resolve IRepository<T> to EFRepository<T> with 1 constructor parameter 
            builder.RegisterType<ExamContext>().As<DbContext>();
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            IContainer container = builder.Build();

            IDependencyResolver resolver = new AutofacResolver(container);
            config.DependencyResolver = resolver;
           
        }
    }
}
