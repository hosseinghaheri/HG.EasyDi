using Microsoft.Extensions.DependencyInjection;

namespace HG.EasyDi
{
    public class LazyDiAttribute : EasyDiAttribute
    {
        public LazyDiAttribute(ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
        {
            ServiceLifetimes = new List<ServiceLifetime>() { serviceLifetime };
            LazyProxy = true;
        }
    }
}
