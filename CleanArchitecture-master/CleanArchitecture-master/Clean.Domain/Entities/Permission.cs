using Clean.Domain.CommonEntities;

namespace Clean.Domain.Entities
{
    public class Permission:BaseEntity
    {
        public string PermissionName { get; set; }
        public string Type { get; set; }
        public virtual ICollection<RolePermission> RolePermissions { get; set; }

    }
}
