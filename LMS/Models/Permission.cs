namespace LMS.Models
{
    public class Permission
    {
        public Guid PermissionId { get; set; }
        public Guid RoleId { get; set; }
        public Guid ModuleId { get; set; }
        public bool CanView { get; set; }
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public bool CanExport { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Role RoleName { get; set; }
        public Module ModuleName { get; set; }
    }
}
