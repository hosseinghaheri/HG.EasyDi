using Microsoft.Extensions.DependencyInjection;

namespace HG.EasyDi
{
    public class ScopedEasyDiAttribute : EasyDiAttribute
    {
        public ScopedEasyDiAttribute(bool lazyProxy = false)
        {
            ServiceLifetimes = new List<ServiceLifetime>() { ServiceLifetime.Scoped };
            LazyProxy = lazyProxy;
        }
    }
}
