using HG.EasyDi.Models;

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
