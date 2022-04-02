using System.ComponentModel.DataAnnotations;

namespace ServerSmartTest.ViewModel
{
    public class UserView
    {
        [Required(ErrorMessage = "Пустое поле")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Неверный формат")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Пустое поле")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Пустое поле")]
        public string ImgProfile { get; set; }

        [Required(ErrorMessage = "Пустое поле")]
        public string Password { get; set; }
        
        [Compare("Password", ErrorMessage = "Пароли отличаются")]
        public string NextPassword { get; set; }

    }
}
