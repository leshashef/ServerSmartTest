

namespace ServerSmartTest.ViewModel
{
    public class UserView
    {
        public string Name { get; set; }    
        public string Email { get; set; }
        public string Password { get; set; }
        public string NextPassword { get; set; }

        private bool CheckPassword()
        {
            return Password == NextPassword;
        }


    }
}
