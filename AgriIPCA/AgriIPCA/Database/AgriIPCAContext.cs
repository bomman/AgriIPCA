using System.Data.Entity;
using AgriIPCA.Models.Products;
using AgriIPCA.Models.Purchases;
using AgriIPCA.Models.Users;

namespace AgriIPCA.Database
{
    public class AgriIPCAContext : DbContext
    {
        public AgriIPCAContext() : base("name=AgriIPCAContext")
        {
            System.Data.Entity.Database.SetInitializer<AgriIPCAContext>(new AgriIPCAInitializer());
        }

        public virtual IDbSet<User> Users { get; set; }

        public virtual IDbSet<Product> Products { get; set; }

        public virtual IDbSet<Purchase> Purchases { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Animal>().ToTable("Animals");
        //    modelBuilder.Entity<Cereals>().ToTable("Cereals");
        //}
    }
}
