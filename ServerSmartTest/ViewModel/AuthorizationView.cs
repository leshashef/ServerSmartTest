using System.ComponentModel.DataAnnotations;

namespace ServerSmartTest.ViewModel
{
    public class AuthorizationView
    {
        [Required(ErrorMessage = "Пустое поле")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Неверный формат")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Пустое поле")]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "Неверный формат")]
        public string Password { get; set; }
    }
}
