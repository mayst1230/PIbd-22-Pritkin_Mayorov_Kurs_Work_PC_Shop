
namespace ComputerEquipmentStoreDatabaseImplement.Models
{
    public class AssemblyComponent
    {
        public int Id { get; set; }

        public int AssemblyId { get; set; }

        public int ComponentId { get; set; }

        public int Count { get; set; }

        public decimal Price { get; set; }

        public virtual Assembly Assembly { get; set; }

        public virtual Component Component { get; set; }
    }
}
