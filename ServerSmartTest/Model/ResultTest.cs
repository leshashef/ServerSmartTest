

namespace ServerSmartTest.Model
{
    public partial class ResultTest
    {
        public int Id { get; set; }
        public int? SmartTestsId { get; set; }
        public string? ResultName { get; set; }

        public virtual SmartTests? SmartTests { get; set; }
    }
}
