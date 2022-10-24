using aspCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace aspCRUD.Controllers
{
    public class StudentCRUD : Controller
    {
        private readonly StudentContext db;
        public StudentCRUD(StudentContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            var GetAllData = db.Tb_Student.ToList();
            return View(GetAllData);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(StudentModel std)
        {
            if(std != null)
            {
                if(std.StudentId == 0)
                {
                    db.Tb_Student.Add(std);
                }
                else
                {
                    db.Entry(std).State = Microsoft.EntityFrameworkCore.EntityState.Modified;                    
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if(id != 0)
            {
                var student = db.Tb_Student.Find(id);
                return View(student);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            if (id != 0)
            {
                var student = db.Tb_Student.Find(id);
                return View(student);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id != 0)
            {
                var res = db.Tb_Student.Find(id);
                if (res != null)
                {
                    db.Remove(res);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
}
