using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string RoleTitle { get; set; }

        public virtual ICollection<User> UsersInRole { get; set; }
        public virtual ICollection<Member> MembersInRole { get; set; }
    }
}
