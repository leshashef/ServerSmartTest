using Microsoft.AspNetCore.Mvc;
using ServerSmartTest.Model;
using ServerSmartTest.Model.Context;
using ServerSmartTest.ViewModel;

namespace ServerSmartTest.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly ILogger<RegistrationController> _logger;
        private readonly AppDBContext _context;

        public RegistrationController(ILogger<RegistrationController> logger, AppDBContext context)
        {
            _logger = logger;
            _context = context;
        }


        [HttpGet]
        public int Get()
        {   
            return 3;
        }

        [HttpPost]
        public UserView Post([FromBody]UserView content)
        {
            return content;
        } 

    }
}
