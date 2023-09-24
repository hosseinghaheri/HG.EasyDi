using HG.EasyDi.Models;
using LazyProxy.ServiceProvider;
using Microsoft.Extensions.DependencyInjection;

namespace HG.EasyDi
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEasyDi(this IServiceCollection services, Action<EasyDiOptions> setupAction)
        {
            var easyDiOptions = new EasyDiOptions();
            if (setupAction != null) setupAction(easyDiOptions);
            services.AddEasyDi(easyDiOptions);
            return services;
        }
        public static IServiceCollection AddEasyDi(this IServiceCollection services, EasyDiOptions easyDiOptions = null)
        {
            if (easyDiOptions == null) easyDiOptions = new EasyDiOptions();
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
                                case ServiceLifetime.Singleton: services.AddLazySingleton(itype, type); break;
                                case ServiceLifetime.Scoped:    services.AddLazyScoped(itype, type);    break;
                                case ServiceLifetime.Transient: services.AddLazyTransient(itype, type); break;
                                default: throw new ArgumentOutOfRangeException();
                            }
                        }
                        else
                        {
                            if (itype == null) services.Add(new ServiceDescriptor(type, type, serviceLifetime));
                            else services.Add(new ServiceDescriptor(itype, type, serviceLifetime));
                        }
                    }
                }
            }

            return services;
        }

        public static void DisplayServicesInConsole(this IServiceCollection services)
        {
            Console.WriteLine("|".PadRight(85, '-') + "|");
            Console.WriteLine($"| Service Type ({services.Count.ToString().PadLeft(6, '0')})".PadRight(73) + "| Lifetime  |");
            Console.WriteLine("|".PadRight(85, '-') + "|");

            foreach (var serviceDescriptor in services)
            {
                var serviceType = serviceDescriptor.ServiceType;
                var genericArguments = serviceType.GetGenericArguments();
                var genericType = genericArguments.Length > 0 ? $"<{(string.Join(", ", genericArguments.Select(s => s.Name)))}>" : "";
                var serviceName = $"{serviceType.Name}{genericType}";
                var lifetime = serviceDescriptor.Lifetime.ToString();

                Console.WriteLine($"| {serviceName.PadRight(70)} | {lifetime.PadRight(9)} |");
            }

            Console.WriteLine("|".PadRight(85, '-') + "|");
        }
    }

}
