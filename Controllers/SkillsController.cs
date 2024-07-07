using CRUDSkills.Data;
using CRUDSkills.Models;
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Skill skill)
        {

            if (ModelState.IsValid){

                var skillFromDb = _context.skills.FirstOrDefault(i => i.Name == skill.Name);




                if (skillFromDb == null)
                {
                    _context.skills.Add(skill);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Name",
                                 "إسم المهارة موجود مسبقا");
                    return View(skill);
                }


                
            }
            {
                return View(skill);
            }

            

           
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var skillFromDb = _context.skills.FirstOrDefault(i => i.Id == id);
            if(skillFromDb == null)
            {
                return NotFound();
            }

            return View(skillFromDb);


        }

        [HttpPost]
        public IActionResult Update(Skill skill)
        {
            if (ModelState.IsValid)
            {
                var skillFromDb = _context.skills.FirstOrDefault(i=>i.Name == skill.Name && i.Id != skill.Id);
                if(skillFromDb != null)
                {
                    ModelState.AddModelError("Name",
                                "إسم المهارة موجود مسبقا");
                    return View(skill);
                }
                else
                {
                    _context.skills.Update(skill);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View(skill);
            }
        }

        public IActionResult Activation(int id)
        {
            var skillFromDb = _context.skills.FirstOrDefault(i => i.Id == id);
            if(skillFromDb == null)
            {
                return NotFound();
            }

            //Check if its active or not
            if(skillFromDb.IsActive == true)
            {
                skillFromDb.IsActive = false;
                _context.skills.Update(skillFromDb);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                skillFromDb.IsActive = true;
                _context.skills.Update(skillFromDb);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var skillFromDb = _context.skills.FirstOrDefault(i => i.Id == id);
            if (skillFromDb == null)
            {
                return NotFound();
            }

            _context.skills.Remove(skillFromDb);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
