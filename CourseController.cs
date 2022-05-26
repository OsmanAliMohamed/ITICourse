using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ItiDays.Models;
namespace ItiDays.Controllers
{
    public class CourseController : Controller
    {
        ITIEntities Data = new ITIEntities();
        // GET: Course
        public ActionResult Index()
        {
            List<Course> crs = Data.Courses.ToList();
            return View(crs);
        }
        public ActionResult Edit(int id)
        {
            ViewBag.Depts = Data.Departments.ToList();
            return View(Data.Courses.FirstOrDefault(c => c.ID == id));
        }
        public ActionResult SaveEdit(int id, Course Newcrs)
        {
            Course crs = Data.Courses.FirstOrDefault(c => c.ID == id);
            crs.Name = Newcrs.Name;
            crs.Hours = Newcrs.Hours;
            crs.DeptID = Newcrs.DeptID;
            Data.SaveChanges();
            return RedirectToAction("Detials","Department",new { id = crs.DeptID });
        }
    }
}