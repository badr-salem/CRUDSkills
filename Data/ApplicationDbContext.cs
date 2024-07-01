using CRUDSkills.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDSkills.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<Skill> skills { get; set; }
	


	}
}
