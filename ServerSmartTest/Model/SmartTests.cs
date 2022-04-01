namespace ServerSmartTest.Model
{
    public class SmartTests
    {
        public SmartTests()
        {
            Quests = new HashSet<Quests>();
        }

        public int Id { get; set; }
        public string? TestName { get; set; }
        public int? UserId { get; set; }

        public virtual Users? Users { get; set; }
        public virtual ICollection<Quests> Quests { get; set; }
    }
}
