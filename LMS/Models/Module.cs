namespace LMS.Models
{
    public class Module
    {
        public Guid ModuleId { get; set; }
        public string ModuleName { get; set; }
        public Guid? ParentModuleId { get; set; }
        public Guid? PageId { get; set; }
        public string RoutePath { get; set; }
        public int ModuleLevel { get; set; } = 1;
        public string?  Icon { get; set; }
        public int DisplayOrder { get; set; } = 0;
        public bool IsVisible { get; set; } = true;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Page Page { get; set; }
        public Module ParentModule { get; set; }
        public ICollection<Permission> Permissions { get; set; }
    }
}
