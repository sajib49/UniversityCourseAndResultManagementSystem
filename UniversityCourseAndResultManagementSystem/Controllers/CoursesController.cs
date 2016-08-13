using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace UniversityCourseAndResultManagementSystem.Models
{
    public class CoursesController : Controller
    {
        private ProjectDb db = new ProjectDb();

        // GET: Courses
        public ActionResult Index()
        {
            var courses = db.Courses.Include(c => c.Department).Include(c => c.Semester);
            return View(courses.ToList());
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            
            ViewBag.DeptId = new SelectList(db.Departments, "DeptId", "DeptName");
            ViewBag.SemesterId = new SelectList(db.Semesters, "SemesterId", "SemesterName");
            return View();
            
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseId,CourseCode,CourseName,Creadit,Description,DeptId,SemesterId")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeptId = new SelectList(db.Departments, "DeptId", "DeptName", course.DeptId);
            ViewBag.SemesterId = new SelectList(db.Semesters, "SemesterId", "SemesterName", course.SemesterId);
            return View(course);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeptId = new SelectList(db.Departments, "DeptId", "DeptCode", course.DeptId);
            ViewBag.SemesterId = new SelectList(db.Semesters, "SemesterId", "SemesterName", course.SemesterId);
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseId,CourseCode,CourseName,Creadit,Description,DeptId,SemesterId")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeptId = new SelectList(db.Departments, "DeptId", "DeptCode", course.DeptId);
            ViewBag.SemesterId = new SelectList(db.Semesters, "SemesterId", "SemesterName", course.SemesterId);
            return View(course);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult GetAllCourse()
        {
            var allCourses = db.Courses.ToList();
            return Json(allCourses, JsonRequestBehavior.AllowGet);
        }


        public JsonResult CourseCodeExits(string coursecode)
        {
            var aCourse = db.Courses.FirstOrDefault(x => x.CourseCode == coursecode);
            if (aCourse == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CourseNameExits(string coursename)
        {
            var aCourse = db.Courses.FirstOrDefault(x => x.CourseName == coursename);
            if (aCourse == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

      
        public ActionResult CourseStatics()
        {
            ViewBag.Departments = new SelectList(db.Departments, "DeptId", "DeptName");
            return View();
        }

        public JsonResult GetCourseStaticsByDeptId(int deptId)
        {
            var courseStatics = (from c in db.Courses join t in db.Teachers on c.TeacherId equals t.TeacherId select new { CourseCode = c.CourseCode, CourseName = c.CourseName, SemesterId = c.SemesterId, TeacherName = t.TeacherName })
                                .Concat(from d in db.Courses.Where(aCourse=>aCourse.CourseId == null) select new { CourseCode = d.CourseCode, CourseName = d.CourseName, SemesterId = d.SemesterId, TeacherName = "Not Yet Assigned" });
            return Json(courseStatics,JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourseByDeptId(int deptId)
        {
            var courses = db.Courses.Where(aCourse => aCourse.DeptId == deptId);
            return Json(courses, JsonRequestBehavior.AllowGet);
        }
    }
}
