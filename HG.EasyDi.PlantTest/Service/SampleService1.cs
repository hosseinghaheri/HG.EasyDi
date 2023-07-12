
namespace HG.EasyDi.PlantTest.Service
{
    public interface ISampleService1
    {
        int Sum(int x,int y);
        int Mul(int x,int y);
        int Diff(int x,int y);
    }
    [EasyDi(ServiceLifetime.Transient)]
    public class SampleService1 : ISampleService1
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
