using ComputerEquipmentStoreDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace ComputerStoreEquipmentFileImplement
{
    public class ComputerEquipmentStoreDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ComputerEquipmentStoreDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Assembly> Assemblies { set; get; }
        public virtual DbSet<AssemblyComponent> AssemblyComponents { set; get; }
        public virtual DbSet<Buyer> Buyers { set; get; }
        public virtual DbSet<Comment> Comments { set; get; }
        public virtual DbSet<Component> Components { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
        public virtual DbSet<Product> Products { set; get; }
        public virtual DbSet<ProductComponent> ProductComponents { set; get; }
        public virtual DbSet<Purchase> Purchases { set; get; }
        public virtual DbSet<PurchaseAssembly> PurchaseAssemblies { set; get; }
        public virtual DbSet<PurchaseProduct> PurchaseProducts { set; get; }
        public virtual DbSet<Seller> Sellers { set; get; }
    }
}
