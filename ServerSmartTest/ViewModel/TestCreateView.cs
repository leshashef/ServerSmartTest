﻿using System.ComponentModel.DataAnnotations;


namespace ServerSmartTest.ViewModel
{
    public class TestCreateView
    {
        [Required(ErrorMessage = "Поле пустое")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Поле пустое")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Неверные данные")]
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
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле пустое")]
        public string JsonText { get; set; }
    }

   
}
