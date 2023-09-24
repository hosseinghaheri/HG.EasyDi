using Microsoft.Extensions.DependencyInjection;

namespace HG.EasyDi
{
    public class EasyDiAttribute : Attribute
    {
        public IEnumerable<ServiceLifetime> ServiceLifetimes;
        public bool LazyProxy;

        public EasyDiAttribute(ServiceLifetime serviceLifetime = ServiceLifetime.Scoped, bool lazyProxy = false)
        {
            ServiceLifetimes = new List<ServiceLifetime>() { serviceLifetime };
            LazyProxy = lazyProxy;
        }
    }
}
