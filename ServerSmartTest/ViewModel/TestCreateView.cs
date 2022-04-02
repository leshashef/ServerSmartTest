using System.ComponentModel.DataAnnotations;


namespace ServerSmartTest.ViewModel
{
    public class TestCreateView
    {
        [Required(ErrorMessage = "Поле пустое")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Поле пустое")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "Неверные данные")]
        public string TestName { get; set; }

        [Required(ErrorMessage = "Поле пустое")]
        public string ImgTest { get; set; }

        [Required(ErrorMessage = "Поле пустое")]
        public ICollection<string> Results { get; set; }

        [Required(ErrorMessage = "Поле пустое")]
        public ICollection<QuestView> Quests { get; set; } 
    }


    public class QuestView
    {
        [Required(ErrorMessage = "Поле пустое")]
        public string QuestName { get; set; }

        [Required(ErrorMessage = "Поле пустое")]
        public string json { get; set; }
        public string lastAnswer { get; set; }
    }

   
}
