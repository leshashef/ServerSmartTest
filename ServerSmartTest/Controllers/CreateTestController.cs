using Microsoft.AspNetCore.Mvc;
using ServerSmartTest.Model;
using ServerSmartTest.Model.Context;
using ServerSmartTest.ViewModel;


namespace ServerSmartTest.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CreateTestController : ControllerBase
    {
        private readonly ILogger<CreateTestController> _logger;
        private readonly AppDBContext _context;

        public CreateTestController(ILogger<CreateTestController> logger, AppDBContext context)
        {
            _logger = logger;
            _context = context;
        }


        [HttpGet]
        public void Get()
        {
        }

        [HttpPost]
        public void Post([FromBody]TestCreateView testData)
        {
            if (ModelState.IsValid)
            {
                var test = new SmartTests();
                test.TestName = testData.TestName;
                test.UserId = testData.UserId;
                test.ImgTest = testData.ImgTest;
                
                foreach(var result in testData.Results)
                {
                    var newResult = new ResultTest();
                    newResult.ResultName = result;
                    test.ResultTests.Add(newResult);
                }

                foreach(var quest in testData.Quests)
                {
                    var newQuest = new Quests();
                    newQuest.NameQuests = quest.Name;
                    newQuest.Jsontext = quest.JsonText;
                    test.Quests.Add(newQuest);
                }

                _context.SmartTests.Add(test);
                _context.SaveChanges();
            }
        }
    }
}
