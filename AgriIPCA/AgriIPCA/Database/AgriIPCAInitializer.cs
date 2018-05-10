using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgriIPCA.Models.Users;

namespace AgriIPCA.Database
{
    public class AgriIPCAInitializer : CreateDatabaseIfNotExists<AgriIPCAContext>
    {
        protected override void Seed(AgriIPCAContext context)
        {
            User defaultUser = new User("user", "user");
            User defaultAdmin = new User("admin", "admin");

            context.Users.Add(defaultUser);
            context.Users.Add(defaultAdmin);
            context.SaveChanges();

            UserRole userRole = new UserRole(defaultUser.Id, Role.User);
            UserRole adminRole = new UserRole(defaultAdmin.Id, Role.Admin);

            context.UserRoles.Add(userRole);
            context.UserRoles.Add(adminRole);
            context.SaveChanges();
        }
    }
}
