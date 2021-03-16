using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerEquipmentStoreDatabaseImplement.Models
{
    public class Buyer
    {
        //ID покупателя
        public int Id { get; set; }

        //Логин покупателя
        [Required]
        public string Login { get; set; }

        //Пароль покупателя
        [Required]
        public string Password { get; set; }

        //Сборки находящиеся в этой покупке
        [ForeignKey("BuyerId")]
        public virtual List<Purchase> Purchase { get; set; }

        //Товары находящиеся в этой покупке
        [ForeignKey("BuyerId")]
        public virtual List<Assembly> Assembly { get; set; }

        //Сборки находящиеся в этой покупке
        [ForeignKey("BuyerId")]
        public virtual List<Comment> Comment { get; set; }
    }
}
