
namespace HG.EasyDi.PlantTest.Service.Cat1
{
    public interface ISampleService3
    {
        int Sum(int x, int y);
        int Mul(int x, int y);
        int Diff(int x, int y);
    }
    [EasyDi(ServiceLifetime.Scoped)]
    public class SampleService3 : ISampleService3
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
