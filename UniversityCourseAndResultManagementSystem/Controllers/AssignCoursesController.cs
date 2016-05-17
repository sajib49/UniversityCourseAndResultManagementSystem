using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.Controllers
{
    public class AssignCoursesController : Controller
    {
        private ProjectDb db = new ProjectDb();
        // GET: /AssignCourses/
        public ActionResult Index()
        {
            ViewBag.Department = new SelectList(db.Departments, "DeptId", "DeptName");
            return View();
        }
	}
}