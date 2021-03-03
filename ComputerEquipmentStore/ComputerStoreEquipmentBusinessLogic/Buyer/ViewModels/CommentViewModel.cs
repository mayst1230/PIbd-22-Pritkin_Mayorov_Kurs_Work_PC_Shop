using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        [DisplayName("Текст комментария")]
        public string Text { get; set; }

        [DisplayName("Дата комментария")]
        public DateTime DateComment { get; set; }
    }
}
