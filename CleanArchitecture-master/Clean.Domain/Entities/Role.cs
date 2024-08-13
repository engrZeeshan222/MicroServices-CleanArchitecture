using Clean.Domain.CommonEntities;

namespace Clean.Domain.Entities
{
    public class Role:BaseEntity
    {
        public string RoleName { get; set; }
        public virtual ICollection<RolePermission> RolePermissions { get; set; }
    }
}
