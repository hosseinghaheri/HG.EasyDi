using LazyProxy;
using Microsoft.Extensions.DependencyInjection;

namespace HG.EasyDi
{
    public static partial class ServiceCollectionExtensions
    { 
        public static IServiceCollection AddLazyTransient(
            this IServiceCollection services,
            Type serviceType,
            Type implementationType)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            if (implementationType == null)
            {
                throw new ArgumentNullException(nameof(implementationType));
            }

            return AddLazy(services, serviceType, implementationType, ServiceLifetime.Transient);
        }

     
        public static IServiceCollection AddLazyTransient(
            this IServiceCollection services,
            Type serviceType,
            Func<IServiceProvider, object> implementationFactory)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            if (implementationFactory == null)
            {
                throw new ArgumentNullException(nameof(implementationFactory));
            }

            return AddLazy(services, serviceType, implementationFactory, ServiceLifetime.Transient);
        }

     
        public static IServiceCollection AddLazyTransient<TService, TImplementation>(this IServiceCollection services)
            where TService : class
            where TImplementation : class, TService
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services.AddLazyTransient(typeof(TService), typeof(TImplementation));
        }


        public static IServiceCollection AddLazyTransient<TService>(
            this IServiceCollection services,
            Func<IServiceProvider, TService> implementationFactory)
            where TService : class
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (implementationFactory == null)
            {
                throw new ArgumentNullException(nameof(implementationFactory));
            }

            return services.AddLazyTransient(typeof(TService), implementationFactory);
        }


        public static IServiceCollection AddLazyTransient<TService, TImplementation>(
            this IServiceCollection services,
            Func<IServiceProvider, TImplementation> implementationFactory)
            where TService : class
            where TImplementation : class, TService
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (implementationFactory == null)
            {
                throw new ArgumentNullException(nameof(implementationFactory));
            }

            return services.AddLazyTransient(typeof(TService), implementationFactory);
        }


        public static IServiceCollection AddLazyScoped(
            this IServiceCollection services,
            Type serviceType,
            Type implementationType)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            if (implementationType == null)
            {
                throw new ArgumentNullException(nameof(implementationType));
            }

            return AddLazy(services, serviceType, implementationType, ServiceLifetime.Scoped);
        }


        public static IServiceCollection AddLazyScoped(
            this IServiceCollection services,
            Type serviceType,
            Func<IServiceProvider, object> implementationFactory)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            if (implementationFactory == null)
            {
                throw new ArgumentNullException(nameof(implementationFactory));
            }

            return AddLazy(services, serviceType, implementationFactory, ServiceLifetime.Scoped);
        }

        public static IServiceCollection AddLazyScoped<TService, TImplementation>(this IServiceCollection services)
            where TService : class
            where TImplementation : class, TService
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services.AddLazyScoped(typeof(TService), typeof(TImplementation));
        }


        public static IServiceCollection AddLazyScoped<TService>(
            this IServiceCollection services,
            Func<IServiceProvider, TService> implementationFactory)
            where TService : class
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (implementationFactory == null)
            {
                throw new ArgumentNullException(nameof(implementationFactory));
            }

            return services.AddLazyScoped(typeof(TService), implementationFactory);
        }

        public static IServiceCollection AddLazyScoped<TService, TImplementation>(
            this IServiceCollection services,
            Func<IServiceProvider, TImplementation> implementationFactory)
            where TService : class
            where TImplementation : class, TService
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (implementationFactory == null)
            {
                throw new ArgumentNullException(nameof(implementationFactory));
            }

            return services.AddLazyScoped(typeof(TService), implementationFactory);
        }


        public static IServiceCollection AddLazySingleton(
            this IServiceCollection services,
            Type serviceType,
            Type implementationType)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            if (implementationType == null)
            {
                throw new ArgumentNullException(nameof(implementationType));
            }

            return AddLazy(services, serviceType, implementationType, ServiceLifetime.Singleton);
        }


        public static IServiceCollection AddLazySingleton(
            this IServiceCollection services,
            Type serviceType,
            Func<IServiceProvider, object> implementationFactory)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            if (implementationFactory == null)
            {
                throw new ArgumentNullException(nameof(implementationFactory));
            }

            return AddLazy(services, serviceType, implementationFactory, ServiceLifetime.Singleton);
        }


        public static IServiceCollection AddLazySingleton<TService, TImplementation>(this IServiceCollection services)
            where TService : class
            where TImplementation : class, TService
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services.AddLazySingleton(typeof(TService), typeof(TImplementation));
        }


        public static IServiceCollection AddLazySingleton<TService>(
            this IServiceCollection services,
            Func<IServiceProvider, TService> implementationFactory)
            where TService : class
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (implementationFactory == null)
            {
                throw new ArgumentNullException(nameof(implementationFactory));
            }

            return services.AddLazySingleton(typeof(TService), implementationFactory);
        }


        public static IServiceCollection AddLazySingleton<TService, TImplementation>(
            this IServiceCollection services,
            Func<IServiceProvider, TImplementation> implementationFactory)
            where TService : class
            where TImplementation : class, TService
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (implementationFactory == null)
            {
                throw new ArgumentNullException(nameof(implementationFactory));
            }

            return services.AddLazySingleton(typeof(TService), implementationFactory);
        }

        private static IServiceCollection AddLazy(
            this IServiceCollection collection,
            Type serviceType,
            Type implementationType,
            ServiceLifetime lifetime)
        {
            var factory = ActivatorUtilities.CreateFactory(implementationType, Array.Empty<Type>());

            Func<IServiceProvider, object> lazyImplementationFactory = (s) => LazyProxyBuilder.CreateInstance(
                serviceType,
                () => factory(s, null));

            var descriptor = new ServiceDescriptor(serviceType, lazyImplementationFactory, lifetime);
            collection.Add(descriptor);
            return collection;
        }

        private static IServiceCollection AddLazy(
            this IServiceCollection collection,
            Type serviceType,
            Func<IServiceProvider, object> implementationFactory,
            ServiceLifetime lifetime)
        {
            Func<IServiceProvider, object> lazyImplementationFactory = (s) => LazyProxyBuilder.CreateInstance(
                serviceType,
                () => implementationFactory(s));

            var descriptor = new ServiceDescriptor(serviceType, lazyImplementationFactory, lifetime);
            collection.Add(descriptor);
            return collection;
        }
    }
}
