using HG.EasyDi.PlantTest.LazyProxyService;
using HG.EasyDi.PlantTest.Service;
using HG.EasyDi.PlantTest.Service.Cat1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HG.EasyDi.PlantTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SampleController : ControllerBase
    {
        private readonly ISampleService1 sampleService1;
        private readonly SampleService2 sampleService2;
        private readonly ISampleService3 sampleService3;

        public SampleController(
            ISampleService1 sampleService1,
            SampleService2 sampleService2,
            ISampleService3 sampleService3,
            ILazyProxyMainService lazyProxyMainService
        )
        {
            this.sampleService1 = sampleService1;
            this.sampleService2 = sampleService2;
            this.sampleService3 = sampleService3;
            LazyProxyMainService = lazyProxyMainService;
        }

        public ILazyProxyMainService LazyProxyMainService { get; }

        [HttpGet("sum/{x}/{y}")]
        public ActionResult<int> Sum(int x, int y)
        {
            var result = sampleService1.Sum(x, y);
            return Ok(result);
        }

        [HttpGet("sum2/{x}/{y}")]
        public ActionResult<int> Sum2(int x, int y)
        {
            var result = sampleService2.Sum(x, y);
            return Ok(result);
        }

        [HttpGet("sum3/{x}/{y}")]
        public ActionResult<int> Sum3(int x, int y)
        {
            var result = sampleService3.Sum(x, y);
            return Ok(result);
        }
        [HttpGet("lazyProxyMainService/DoWork")]
        public ActionResult<int> lazyProxyMainService_DoWork()
        {
            LazyProxyMainService.DoWork();
            return Ok();
        }

    }

}
