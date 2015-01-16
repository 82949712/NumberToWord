using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace NumberToWord.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();

            //var formater = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            //formater.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //GlobalConfiguration.Configuration.Formatters.Add(new MyJSONPFomarter());
        }
    }

    public class MyJSONPFomarter : MediaTypeFormatter
    {
        public MyJSONPFomarter()
        {
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/javascript"));


        }

        public override bool CanReadType(Type type)
        {
            return true;
        }

        public override bool CanWriteType(Type type)
        {
            return true;
        }

        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content,
            TransportContext transportContext)
        {
            return base.WriteToStreamAsync(type, value, writeStream, content, transportContext);
        }
    }
}
