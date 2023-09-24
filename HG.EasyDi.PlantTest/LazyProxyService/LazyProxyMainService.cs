﻿namespace HG.EasyDi.PlantTest.LazyProxyService
{
    public interface ILazyProxyMainService
    {
        void DoWork();
    }
    [LazyDi(ServiceLifetime.Scoped)]
    public class LazyProxyMainService : ILazyProxyMainService
    {
        public LazyProxyMainService()
        {
            Console.WriteLine("LazyProxyMainService -> Ctor");
        }
        public void DoWork()
        {
            Console.WriteLine("LazyProxyMainService -> DoWork");
        }
    }
}
