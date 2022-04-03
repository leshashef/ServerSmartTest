using Microsoft.AspNetCore.Mvc;
using ServerSmartTest.Model.Context;
using ServerSmartTest.ViewModel;
using ServerSmartTest.Services;

namespace ServerSmartTest.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly ILogger<AuthorizationController> _logger;
        private readonly AppDBContext _context;
        private readonly AuthorizationServices _authorization = new AuthorizationServices();

        public AuthorizationController(ILogger<AuthorizationController> logger, AppDBContext context)
        {
            _logger = logger;
            _context = context;
        }


        [HttpGet]
        public void Get()
        {

        }

        [HttpPost]
        public async Task<OkResult> Post(AuthorizationView user)
        {
            var checkUser = _context.Users.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
            if(checkUser != null) 
            {
                await _authorization.Authenticate(user.Email,HttpContext);
            }
            return Ok();
        }
    }
}

