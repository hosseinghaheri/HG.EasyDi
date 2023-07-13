
namespace HG.EasyDi.PlantTest.Service
{
    [EasyDi(ServiceLifetime.Transient)]
    public class SampleService2
    {
        public int Diff(int x, int y)
        {
            return x - y;
        }

        public int Mul(int x, int y)
        {
            return x * y;
        }

        public int Sum(int x, int y)
        {
            return x + y;
        }
    }
}
