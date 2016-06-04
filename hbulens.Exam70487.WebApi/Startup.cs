using hbulens.Exam70487.WebApi.Formatters;
using Microsoft.Owin.Cors;
using Owin;
using System.Web.Http;

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
            appBuilder.UseCors(CorsOptions.AllowAll);

            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            appBuilder.UseWebApi(config);

            config.Formatters.Add(new CsvFormatter());
        }
    }
}
