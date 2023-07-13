using HG.EasyDi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HG.EasyDi
{
    public static class EasyDiOptionsExtensions
    {
        public static EasyDiOptions SetNamespaceRootToScan(this EasyDiOptions source,string namespaceRoot)
        {
            source.NamespaceRootToScan = namespaceRoot;
            return source;
        }
    }
}
