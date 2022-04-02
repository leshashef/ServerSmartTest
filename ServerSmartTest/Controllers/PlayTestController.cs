using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerSmartTest.Model;
using ServerSmartTest.Model.Context;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerSmartTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayTestController : ControllerBase
    {

        private readonly ILogger<RegistrationController> _logger;
        private readonly IWebHostEnvironment _webhostenv;
        private readonly AppDBContext _context;

        public PlayTestController(ILogger<RegistrationController> logger, AppDBContext context, IWebHostEnvironment webhostenv)
        {
            _logger = logger;
            _context = context;
            _webhostenv = webhostenv;
        }

        // GET: api/<PlayTestController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            
            return new string[] { "value1", "value2" };
        }

        // GET api/<PlayTestController>/5
        [HttpGet("{id}")]
        public SmartTests Get(int id)
        {
            var Test = _context.SmartTests.Include(x=>x.User)
                                            .Include(x=>x.Quests)
                                            .Include(x=>x.ResultTests)
                                            .FirstOrDefault(Ok => Ok.Id == id);
            if(Test == null)
            {
                return null;
            }
            Test.User.SmartTests = null;
            foreach (var quest in Test.Quests)
            {
                quest.SmartTests = null;
            }
            foreach (var result in Test.ResultTests)
            {
                result.SmartTests = null;
            }

            return Test;
        }

        // POST api/<PlayTestController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PlayTestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PlayTestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
