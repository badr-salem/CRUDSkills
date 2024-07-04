using System.ComponentModel.DataAnnotations;

namespace CRUDSkills.Models
{
	public class Skill
	{
		public int Id { get; set; }

		[Required(ErrorMessage ="هذا الحقل إجباري")]
		public string Name { get; set; }

		public bool IsActive { get; set; }
	}
}
