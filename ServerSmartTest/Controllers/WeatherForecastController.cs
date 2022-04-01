using Microsoft.AspNetCore.Mvc;
using ServerSmartTest.Model;
using ServerSmartTest.Model.Context;

namespace ServerSmartTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly AppDBContext context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, AppDBContext _context)
        {
            _logger = logger;
            context = _context;
        }

        [HttpGet]
        public IEnumerable<Users> Get()
        {
            return context.Users.ToList();
        }
    }
}