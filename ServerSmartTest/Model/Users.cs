namespace ServerSmartTest.Model
{
    public class Users
    {
        public Users()
        {
            SmartTests = new HashSet<SmartTests>();
        }

        public int Id { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? ImgProfile { get; set; }
        public virtual ICollection<SmartTests> SmartTests { get; set; }
    }
}
