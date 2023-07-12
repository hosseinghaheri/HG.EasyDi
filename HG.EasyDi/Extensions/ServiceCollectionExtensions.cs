using HG.EasyDi.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HG.EasyDi
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEasyDi(this IServiceCollection services, Action<EasyDiOptions> setupAction)
        {
            var easyDiOptions = new EasyDiOptions();
            if(setupAction != null) setupAction(easyDiOptions);
            services.AddEasyDi(easyDiOptions);
            return services;
        }
        public static IServiceCollection AddEasyDi(this IServiceCollection services, EasyDiOptions easyDiOptions = null)
        {
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => string.IsNullOrWhiteSpace(easyDiOptions.NamespaceRootToScan) || t.Namespace == easyDiOptions.NamespaceRootToScan && t.GetCustomAttributes(typeof(EasyDiAttribute), true).Length > 0);

            foreach (var type in types)
            {
                var attribute = (EasyDiAttribute)type.GetCustomAttributes(typeof(EasyDiAttribute), true).FirstOrDefault();
                if (attribute != null)
                {
                    foreach (var serviceLifetime in attribute.ServiceLifetimes)
                    {
                        switch (serviceLifetime)
                        {
                            case ServiceLifetime.Singleton:
                                //services.AddSingleton(type);
                                services.Add(new ServiceDescriptor(type.GetInterfaces().FirstOrDefault(), type, ServiceLifetime.Singleton));
                                break;
                            case ServiceLifetime.Scoped:
                                //services.AddScoped(type);
                                services.Add(new ServiceDescriptor(type.GetInterfaces().FirstOrDefault(), type, ServiceLifetime.Scoped));
                                break;
                            case ServiceLifetime.Transient:
                                //services.AddTransient(type);
                                services.Add(new ServiceDescriptor(type.GetInterfaces().FirstOrDefault(), type, ServiceLifetime.Transient));
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }
                }
            }

            return services;
        }
    }

}
