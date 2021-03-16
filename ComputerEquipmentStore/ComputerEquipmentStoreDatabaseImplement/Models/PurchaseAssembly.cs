using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerEquipmentStoreDatabaseImplement.Models
{
    public class PurchaseAssembly
    {
        public int Id { get; set; }

        public int? PurchaseId { get; set; }

        public int? AssemblyId { get; set; }

        public virtual Purchase Purchase { get; set; }

        public virtual Assembly Assembly { get; set; }
    }
}
