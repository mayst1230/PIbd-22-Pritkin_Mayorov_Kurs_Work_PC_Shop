using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerEquipmentStoreDatabaseImplement.Models
{
    public class AssemblyComponent
    {
        public int Id { get; set; }

        public int AssemblyId { get; set; }

        public int ComponentId { get; set; }

        public virtual Assembly Assembly { get; set; }

        public virtual Component Component { get; set; }
    }
}
