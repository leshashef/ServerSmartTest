using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerSmartTest.Model;
using ServerSmartTest.Model.Context;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerSmartTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListTestController : ControllerBase
    {

        private readonly ILogger<RegistrationController> _logger;
        private readonly AppDBContext _context;

        public ListTestController(ILogger<RegistrationController> logger, AppDBContext context)
        {
            _logger = logger;
            _context = context;
        }
        // GET: api/<ListTestController>
        [HttpGet]
        public IEnumerable<SmartTests> Get()
        {
            return _context.SmartTests.Include(x=>x.Users).Include(x=>x.Quests).ToList();
        }
            
        // GET api/<ListTestController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ListTestController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ListTestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ListTestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
