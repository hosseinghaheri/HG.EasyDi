using HG.EasyDi.PlantTest.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HG.EasyDi.PlantTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SampleController : ControllerBase
    {
        private readonly ISampleService1 _sampleService;

        public SampleController(ISampleService1 sampleService)
        {
            _sampleService = sampleService;
        }

        [HttpGet("sum/{x}/{y}")]
        public ActionResult<int> Sum(int x, int y)
        {
            var result = _sampleService.Sum(x, y);
            return Ok(result);
        }

        [HttpGet("mul/{x}/{y}")]
        public ActionResult<int> Mul(int x, int y)
        {
            var result = _sampleService.Mul(x, y);
            return Ok(result);
        }

        [HttpGet("diff/{x}/{y}")]
        public ActionResult<int> Diff(int x, int y)
        {
            var result = _sampleService.Diff(x, y);
            return Ok(result);
        }
    }

}
