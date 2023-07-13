using HG.EasyDi.PlantTest.Service;
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

        public SampleController(ISampleService1 sampleService1,SampleService2 sampleService2)
        {
            this.sampleService1 = sampleService1;
            this.sampleService2 = sampleService2;
        }

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

    }

}
