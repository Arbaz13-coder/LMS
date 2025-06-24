using System.ComponentModel.DataAnnotations;

namespace LMS.Models
{
    public class Page
    {
        public Guid PageId { get; set; } = Guid.NewGuid();

        [Required]
        public string PageName { get; set; }

        [Required]
        public string PageUrl { get; set; }  // Route, e.g. "/dashboard/reports"

        public string PageComponent { get; set; } // Optional: React/Angular component name

        public string Icon { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public ICollection<Module> Modules { get; set; }  // Navigation property
    }
}
