using Microsoft.AspNetCore.Mvc;
using ServerSmartTest.Model;
using ServerSmartTest.Model.Context;
using ServerSmartTest.Services;
using ServerSmartTest.ViewModel;

namespace ServerSmartTest.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly ILogger<RegistrationController> _logger;
        private readonly AppDBContext _context;
        private readonly AuthorizationServices _authorization = new AuthorizationServices();

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
        public async Task<OkResult> Post([FromBody]UserView content)
        {
            await _authorization.Authenticate(content.Email, HttpContext);
            //if (ModelState.IsValid)
            //{
            //    var user = new Users();
            //    user.UserName = content.Name;
            //    user.Email = content.Email;
            //    user.Password = content.Password;
            //    user.ImgProfile = "defaultPhoto";
            //    _context.Users.Add(user);
            //    await _authorization.Authenticate(content.Email);
            //    _context.SaveChanges();
            //}
            return Ok();
        } 

    }
}
