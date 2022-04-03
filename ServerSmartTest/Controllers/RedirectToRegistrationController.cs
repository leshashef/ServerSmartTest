using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerSmartTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedirectToRegistrationController : ControllerBase
    {
        // GET: api/<RedirectToRegistrationController>
        [HttpGet]
        public ResultCheck Get()
        {
            ResultCheck resultCheck = new ResultCheck() { Redirect = "/registration" };
            return resultCheck;
        }

        // GET api/<RedirectToRegistrationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RedirectToRegistrationController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RedirectToRegistrationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RedirectToRegistrationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
    public class ResultCheck
    {
       public string Redirect { get; set; }
    }
}
