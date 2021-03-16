using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerEquipmentStoreDatabaseImplement.Models
{
   public class Seller
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }

        [ForeignKey("SellerId")]
        public virtual List<Fridge> Fridges { get; set; }
        [ForeignKey("SellerId")]
        public virtual List<Request> Requests { get; set; }
    }
}
