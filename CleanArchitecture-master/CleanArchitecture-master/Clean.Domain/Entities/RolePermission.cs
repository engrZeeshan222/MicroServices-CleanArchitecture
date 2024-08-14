using Clean.Domain.CommonEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Domain.Entities
{
    public class RolePermission:BaseEntity
    {
        [ForeignKey("RoleId")]
        public int RoleId { get; set; }
        public Role Role { get; set; }
        [ForeignKey("PermissionId")]
        public int PermissionId { get; set; }
        public Permission Permission { get; set; }
    }
}
