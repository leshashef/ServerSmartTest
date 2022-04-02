namespace ServerSmartTest.Model
{
    public class SmartTests
    {
        public SmartTests()
        {
            Quests = new HashSet<Quests>();
            ResultTests = new HashSet<ResultTest>();
        }

        public int Id { get; set; }
        public string? TestName { get; set; }
        public int? UserId { get; set; }
        public string? ImgPath { get; set; }

        public virtual Users? User { get; set; }
        public virtual ICollection<Quests> Quests { get; set; }
        public virtual ICollection<ResultTest> ResultTests { get; set; }
    }
}
