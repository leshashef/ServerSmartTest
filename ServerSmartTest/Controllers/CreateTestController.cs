using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServerSmartTest.Model;
using ServerSmartTest.Model.Context;
using ServerSmartTest.ViewModel;


namespace ServerSmartTest.Controllers
{
    [Authorize]
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
        public OkResult Post([FromBody]TestCreateView testData)
        { 
                var test = new SmartTests();
                test.TestName = testData.TestName;
                test.UserId = testData.UserId;
                test.ImgTest = testData.ImgTest;
                _context.SmartTests.Add(test);
                foreach(var result in testData.Results)
                {
                    var newResult = new ResultTest();
                    newResult.ResultName = result;
                    newResult.SmartTests = test;
                    test.ResultTests.Add(newResult);
                }

                foreach(var quest in testData.Quests)
                {
                    var newQuest = new Quests();
                    newQuest.NameQuests = quest.QuestName;
                    newQuest.Jsontext = quest.json;
                    Console.WriteLine(newQuest.Jsontext);
                    newQuest.SmartTests = test;
                    test.Quests.Add(newQuest);
                }

                
                _context.SaveChanges();
            

           return Ok();
        }
    }
}
