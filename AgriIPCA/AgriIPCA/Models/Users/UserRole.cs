using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriIPCA.Models.Users
{
    public enum Role
    {
        User, Admin
    }

    [Table("UserRoles")]
    public class UserRole
    {
        public UserRole()
        {        
        }

        public UserRole(int userId, Role role)
        {
            UserId = userId;
            Role = role;
        }

        [Key]
        public int UserId { get; set; }

        public Role Role { get; set; }
    }
}
