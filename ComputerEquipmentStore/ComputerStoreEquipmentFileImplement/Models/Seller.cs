using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ComputerEquipmentStoreDatabaseImplement.Models
{
   public class Seller
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
    }
}
