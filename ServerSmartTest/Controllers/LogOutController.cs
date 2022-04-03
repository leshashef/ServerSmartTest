using Microsoft.AspNetCore.Mvc;
using ServerSmartTest.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerSmartTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogOutController : ControllerBase
    {

        private readonly AuthorizationServices _authorization = new AuthorizationServices();
        // GET: api/<LogOutController>
        [HttpGet]
        public async Task<OkResult> Get()
        {
            await _authorization.Logout(HttpContext);
            return Ok();
        }

    }
}
