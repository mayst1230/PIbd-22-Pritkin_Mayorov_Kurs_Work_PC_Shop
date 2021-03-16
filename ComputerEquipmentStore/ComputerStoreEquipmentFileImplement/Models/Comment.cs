using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerEquipmentStoreDatabaseImplement.Models
{
    public class Comment
    {
        //ID покупки
        public int Id { get; set; }

        //Текст комментария
        [Required]
        public string Text { get; set; }

        //Дата комменария
        [Required]
        public DateTime DateComment { get; set; }

        [Required]
        public Buyer Buyer { get; set; }

        [ForeignKey("BuyerId")]
        public Assembly Assembly { get; set; }
    }
}
