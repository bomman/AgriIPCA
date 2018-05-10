using System.Data.Entity;
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

        public virtual IDbSet<UserRole> UserRoles { get; set; }
    }
}
