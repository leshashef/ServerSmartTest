using System.ComponentModel.DataAnnotations;

namespace ServerSmartTest.ViewModel
{
    public class SmartTestView
    {
        [Required(ErrorMessage = "Поле пустое")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Неверное имя теста")]
        public string NameTest { get; set; }
        [Required(ErrorMessage = "Поле пустое")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Поле пустое")]
        public string ImgTest { get; set; }


    }
}
