using CRUDSkills.Data;
using Microsoft.AspNetCore.Mvc;

namespace CRUDSkills.Controllers
{
    public class SkillsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SkillsController(ApplicationDbContext context)
        {
                _context = context;
        }
        public IActionResult Index()
        {
            var list = _context.skills.ToList();
            return View(list);
        }
    }
}
