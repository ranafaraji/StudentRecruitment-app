using Microsoft.AspNetCore.Mvc;
using StudentRecuitmentProject.DBmodels;
using StudentRecuitmentProject.Models;
using System.Diagnostics;

namespace StudentRecuitmentProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentRecuitmentProjectDbContext _context;

        public HomeController(StudentRecuitmentProjectDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
           var students =  _context.Students.ToList();
            return View(students);
        }
        [HttpGet]
        public IActionResult addOrUpdateStudent(int? id)
        {
            var student = _context.Students.FirstOrDefault(s=>s.StudentId == id);
            return View(student);
        }
        [HttpPost]
        public IActionResult addOrUpdateStudent(Student student)
        {
   
            if (student != null)
            {
                if (student.StudentId != null && student.StudentId != 0)
                {
                    _context.Students.Update(student);
                }
                else
                {
                    _context.Students.Add(student);
                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        } 
        
        public IActionResult DeleteStudent(int id )
        {

            var studentExist = _context.Students.FirstOrDefault(s => s.StudentId == id);
            if (studentExist != null)
            {
                _context.Students.Remove(studentExist);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
