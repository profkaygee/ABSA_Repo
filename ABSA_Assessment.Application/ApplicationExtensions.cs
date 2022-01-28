using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ABSA_Assessment.Application
{
    /// <summary>
    /// The application extensions.
    /// </summary>
    public static class ApplicationExtensions
    {
        /// <summary>
        /// Adds the application layer.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }

        /// <summary>
        /// Clones the specified source.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static T Clone<T>(this T source)
        {
            if (source is null)
                return default;

            var deserializeSettings = new JsonSerializerSettings
            { ObjectCreationHandling = ObjectCreationHandling.Replace };
            var serializeSettings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source, serializeSettings),
                deserializeSettings);
        }
    }
}
