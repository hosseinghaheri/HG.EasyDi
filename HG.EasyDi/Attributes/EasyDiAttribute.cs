using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HG.EasyDi
{
    public class EasyDiAttribute:Attribute
    {
        public readonly IEnumerable<ServiceLifetime> ServiceLifetimes;
        public EasyDiAttribute(ServiceLifetime serviceLifetime=ServiceLifetime.Singleton)
        {
            ServiceLifetimes = new List<ServiceLifetime>() { serviceLifetime };
        }
    }
}
