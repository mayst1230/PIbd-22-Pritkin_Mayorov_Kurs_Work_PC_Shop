using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerEquipmentStoreDatabaseImplement.Models
{
    public class Comment
    {
        //ID комментария
        public int Id { get; set; }

        //ID сборки
        public int AssemblyId { get; set; }

        //ID покупателя
        public int BuyerId { get; set; }

        //Текст комментария
        [Required]
        public string Text { get; set; }

        //Дата комменария
        [Required]
        public DateTime DateComment { get; set; }

        public Assembly Assembly { get; set; }

        public Buyer Buyer { get; set; }
       
    }
}
