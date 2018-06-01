using System;
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
            context.Products.Add(horse);

            Cereals wheat = new Cereals("Crunchy", 0.22m, 1000);
            context.Products.Add(wheat);

            Meat meat = new Meat("Pork Meat", 5.89m, 100, new DateTime(2018, 5, 27));
            context.Products.Add(meat);

            DairyProduct milk = new DairyProduct("Mr. Milk", 0.7m, 1000, new DateTime(2018, 3, 28));
            context.Products.Add(milk);

            DairyProduct cheese = new DairyProduct("Alpy", 7, 30, new DateTime(2018, 7, 12));
            context.Products.Add(cheese);

            context.SaveChanges();
        }
    }
}
