using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerEquipmentStoreDatabaseImplement.Models
{
    public class Assembly
    {
        //ID покупки
        public int Id { get; set; }

        public int BuyerId { get; set; }

        //Cтоимость сборки
        [Required]
        public int Cost { get; set; }

        //Название сборки
        [Required]
        public string AssemblyName { get; set; }

        
        public virtual Buyer Buyer { get; set; }

        //Продукты в которых эта сборка находится
        [ForeignKey("AssemblyId")]
        public virtual List<PurchaseAssembly> PurchaseAssemblies { get; set; }

        //Комплеткующие находящиеся в этой покупке
        [ForeignKey("AssemblyId")]
        public virtual List<AssemblyComponent> AssemblyComponents { get; set; }

        //Комментарии к сборке
        [ForeignKey("AssemblyId")]
        public virtual List<Comment> Comments { get; set; }

    }
}
