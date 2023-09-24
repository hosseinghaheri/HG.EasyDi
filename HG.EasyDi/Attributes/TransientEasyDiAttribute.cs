using Microsoft.Extensions.DependencyInjection;

namespace HG.EasyDi
{
    public class TransientEasyDiAttribute : EasyDiAttribute
    {
        public TransientEasyDiAttribute(bool lazyProxy = false)
        {
            ServiceLifetimes = new List<ServiceLifetime>() { ServiceLifetime.Transient };
            LazyProxy = lazyProxy;
        }
    }

}
