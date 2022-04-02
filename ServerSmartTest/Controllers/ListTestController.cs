using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerSmartTest.Model;
using ServerSmartTest.Model.Context;
using ServerSmartTest.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerSmartTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListTestController : ControllerBase
    {

        private readonly ILogger<RegistrationController> _logger;
        private readonly IWebHostEnvironment _webhostenv;
        private readonly AppDBContext _context;

        public ListTestController(ILogger<RegistrationController> logger, AppDBContext context, IWebHostEnvironment webhostenv)
        {
            _logger = logger;
            _context = context;
            _webhostenv = webhostenv;   
        }
        // GET: api/<ListTestController>
        [HttpGet]
        public IEnumerable<SmartTests> Get()
        {
            var Tests = _context.SmartTests.Include(x=>x.User).ToList();
            if (Tests == null)
            {
                return null;
            }
            foreach(var test in Tests)
            {
                test.User.SmartTests = null;
            }
            return Tests;
        }
            
        // GET api/<ListTestController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


    }
}
