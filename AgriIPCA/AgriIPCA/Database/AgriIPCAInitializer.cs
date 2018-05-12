using System.Data.Entity;
using AgriIPCA.Models.Products;
using AgriIPCA.Models.Users;

namespace AgriIPCA.Database
{
    public class AgriIPCAInitializer : CreateDatabaseIfNotExists<AgriIPCAContext>
    {
        protected override void Seed(AgriIPCAContext context)
        {
            User defaultUser = new User("user", "user", Role.User);
            User defaultAdmin = new User("admin", "admin", Role.Admin);

            context.Users.Add(defaultUser);
            context.Users.Add(defaultAdmin);
            context.SaveChanges();

            Animal horse = new Animal("Long horse", 2000, 2, "horse");
            //context.Animals.Add(horse);
            context.Products.Add(horse);
            context.SaveChanges();

            Cereals wheat = new Cereals("Best weed", 0.22m, 1000);
            context.Products.Add(wheat);
            //context.Cereals.Add(wheat);
            context.SaveChanges();
        }
    }
}
