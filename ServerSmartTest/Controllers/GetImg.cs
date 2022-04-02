using Microsoft.AspNetCore.Mvc;
using ServerSmartTest.Model.Context;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerSmartTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetImgController : ControllerBase
    {
        private readonly ILogger<RegistrationController> _logger;
        private readonly IWebHostEnvironment _webhostenv;
        private readonly AppDBContext _context;

        public GetImgController(ILogger<RegistrationController> logger, AppDBContext context, IWebHostEnvironment webhostenv)
        {
            _logger = logger;
            _context = context;
            _webhostenv = webhostenv;
        }
        // GET: api/<GetImg>
        //[HttpGet]
        //public File Get()
        //{
        //    System.IO.File.ReadAllBytes(_webhostenv.ContentRootPath + "")
        //    return File(System.Text.Encoding.UTF8.GetBytes());
        //}

        [HttpGet]
        public string Get()
        {
            byte[] data = System.IO.File.ReadAllBytes(_webhostenv.ContentRootPath + "wwwroot\\Source\\ImgTest\\test-img.jpg");
            string dataBase = Convert.ToBase64String(data);

            return Convert.ToBase64String(data);
        }

        // GET api/<GetImg>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GetImg>
        [HttpPost]
        public List<ImgGet> Post([FromBody] List<ImgGet> value)
        {
            return value;
        }

        // PUT api/<GetImg>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GetImg>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
    public class ImgGet
    {
        public string Pictures { get; set; }
    }
}
