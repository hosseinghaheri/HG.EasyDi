using Microsoft.Extensions.DependencyInjection;

namespace HG.EasyDi
{
    public class LasyDiAttribute : EasyDiAttribute
    {
        public LasyDiAttribute(ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
        {
            ServiceLifetimes = new List<ServiceLifetime>() { serviceLifetime };
            LazyProxy = true;
        }
    }
   

}
