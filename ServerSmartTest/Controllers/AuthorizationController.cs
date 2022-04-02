using Microsoft.AspNetCore.Mvc;
using ServerSmartTest.Model.Context;
using ServerSmartTest.ViewModel;
using ServerSmartTest.Services;

namespace ServerSmartTest.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController
    {
        private readonly ILogger<AuthorizationController> _logger;
        private readonly AppDBContext _context;
        private readonly AuthorizationServices _authorization;

        public AuthorizationController(ILogger<AuthorizationController> logger, AppDBContext context, AuthorizationServices authorization)
        {
            _logger = logger;
            _context = context;
            _authorization = authorization;
        }


        [HttpGet]
        public void Get()
        {

        }

        [HttpPost]
        public async Task Post(AuthorizationView user)
        {
            var checkUser = _context.Users.FirstOrDefault(x => x.UserName == user.Name && x.Password == user.Password);
            if(checkUser != null) 
            {
                await _authorization.Authenticate(user.Name);
            }

        }
    }
}

