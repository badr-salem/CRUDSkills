using System.ComponentModel.DataAnnotations;

namespace CRUDSkills.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="هذا الحقل إلزامي")]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
    }
}
