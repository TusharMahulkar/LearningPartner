using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eShopWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("Time")]
        public string GetCurrentTimeStamp()
        {
            return System.DateTime.Now.ToString();
        }
    }
}
