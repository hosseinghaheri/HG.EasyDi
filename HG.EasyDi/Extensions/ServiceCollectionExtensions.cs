﻿using HG.EasyDi.Models;
using LazyProxy.ServiceProvider;
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
            if(easyDiOptions == null) easyDiOptions = new EasyDiOptions();
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => 
                    (
                        string.IsNullOrWhiteSpace(easyDiOptions.NamespaceRootToScan) 
                        || (!string.IsNullOrWhiteSpace(t.Namespace) && t.Namespace.StartsWith(easyDiOptions.NamespaceRootToScan))
                    )
                    && t.GetCustomAttributes(typeof(EasyDiAttribute), true).Length > 0);

            foreach (var type in types)
            {
                var attribute = (EasyDiAttribute)type.GetCustomAttributes(typeof(EasyDiAttribute), true).FirstOrDefault();
                if (attribute != null)
                {
                    foreach (var serviceLifetime in attribute.ServiceLifetimes)
                    {
                        var itype = type.GetInterfaces().FirstOrDefault();
                        if (attribute.LazyProxy)
                        {
                            if (itype == null) throw new Exception("To use Lazy Proxy must be inherit class from a Interface");
                            switch (serviceLifetime)
                            {
                                case ServiceLifetime.Singleton:
                                    services.AddLazySingleton(itype, type);
                                    break;
                                case ServiceLifetime.Scoped:
                                    services.AddLazyScoped(itype, type);
                                    break;
                                case ServiceLifetime.Transient:
                                    services.AddLazyTransient(itype, type);
                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException();
                            }
                        }
                        else
                        {
                            switch (serviceLifetime)
                            {
                                case ServiceLifetime.Singleton:
                                    if (itype == null) services.AddSingleton(type);
                                    else services.Add(new ServiceDescriptor(itype, type, ServiceLifetime.Singleton));
                                    break;
                                case ServiceLifetime.Scoped:
                                    if (itype == null) services.AddScoped(type);
                                    else services.Add(new ServiceDescriptor(itype, type, ServiceLifetime.Scoped));
                                    break;
                                case ServiceLifetime.Transient:
                                    if (itype == null) services.AddTransient(type);
                                    else services.Add(new ServiceDescriptor(itype, type, ServiceLifetime.Transient));
                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException();
                            }
                        }
                    }
                }
            }

            return services;
        }
    }

}
