using ItiDays.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ItiDays.Controllers
{
    public class DepartmentController : Controller
    {
        ITIEntities Data = new ITIEntities();
        public ActionResult Search(string DeptName)
        {
            ViewBag.DeptName = DeptName;
            List<Department> depts = Data.Departments.Where(d => d.Name.Contains(DeptName)).ToList();
            return View("GetAll", depts);
        }
        public ActionResult GetAll()
        {
            List<Department> depts = Data.Departments.ToList();
            return View(depts);
        }
        public ActionResult Detials(int id)
        {
            return View(Data.Departments.SingleOrDefault(d => d.ID == id));
        }
        
        public ActionResult TestVB()
        {
            List<string> StudentNames = new List<string>();
            StudentNames.Add("osman");
            StudentNames.Add("ali");
            StudentNames.Add("mohamed");
            StudentNames.Add("mansour");
            ViewData["names"] = StudentNames;
            return View();
        }
        public ActionResult NewDept()
        {
            return View();
        }
        public ActionResult SaveNewDept(Department dept)
        {
            
            
            #region request object
            /*
            string name = "", manager = "";
            if(Request.QueryString["Name"]!="")
            {
                name = Request.QueryString["Name"];
            }
            if(Request.QueryString["Manager"] != "")
            {
                manager = Request.QueryString["Manager"];
            }
            */
            #endregion
            
            if (dept.Name != "" && dept.Manager != "")
            {
                
                
                Data.Departments.Add(dept);
                Data.SaveChanges();
                return RedirectToAction("GetAll");
            }
            return View();
        }
    }
}