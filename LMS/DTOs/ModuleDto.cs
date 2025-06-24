using LMS.Models;

namespace LMS.DTOs
{
    public class ModuleDto
    {
        public Guid ModuleId { get; set; }
        public string ModuleName { get; set; }
        public string RoutePath { get; set; }
        public string Icon { get; set; }
        public List<ModuleDto> Children { get; set; } = new();
    }
    

   
}
