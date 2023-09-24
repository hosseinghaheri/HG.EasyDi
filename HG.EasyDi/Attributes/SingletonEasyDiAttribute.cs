using Microsoft.Extensions.DependencyInjection;

namespace HG.EasyDi
{
    public class SingletonEasyDiAttribute : EasyDiAttribute
    {
        public SingletonEasyDiAttribute(bool lazyProxy = false)
        {
            ServiceLifetimes = new List<ServiceLifetime>() { ServiceLifetime.Singleton };
            LazyProxy = lazyProxy;
        }
    }
}
