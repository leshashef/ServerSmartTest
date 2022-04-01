namespace ServerSmartTest.Model
{
    public class Quests
    {
        public int Id { get; set; }
        public string? NameQuests { get; set; }
        public int? SmartTestsId { get; set; }
        public string? Jsontext { get; set; }

        public virtual SmartTests? SmartTests { get; set; }
    }
}
