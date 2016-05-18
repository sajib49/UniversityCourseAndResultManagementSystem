using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.Controllers
{
    public class StudentsController : Controller
    {
        private ProjectDb db = new ProjectDb();

        // GET: Students
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.Department);
            return View(students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.DeptId = new SelectList(db.Departments, "DeptId", "DeptName");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,StudentName,Email,ContactNo,RegDate,Address,DeptId,RegNo")] Student student)
        {
            if (ModelState.IsValid)
            {
                student.RegNo = GetStudentRegNo(student);
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeptId = new SelectList(db.Departments, "DeptId", "DeptCode", student.DeptId);
            return View(student);
        }

        private string GetStudentRegNo(Student aStudent)
        {

            Department aDepartment = db.Departments.FirstOrDefault(aDept => aDept.DeptId == aStudent.DeptId);
            int countDeptStd =
                db.Students.Count(aStd => (aStd.DeptId == aStudent.DeptId) && (aStd.RegDate.Year == aStudent.RegDate.Year))+1;
            int noOfZeroToBeAdded = 3 - countDeptStd.ToString().Length;
            string noOfZero = "";
            for (int i = 0; i < noOfZeroToBeAdded; i++)
            {
                noOfZero += "0";
            }

            return aDepartment.DeptCode + "-" + aStudent.RegDate.Year + "-" + noOfZero + countDeptStd;

        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeptId = new SelectList(db.Departments, "DeptId", "DeptCode", student.DeptId);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,StudentName,Email,ContactNo,RegDate,Address,DeptId,RegNo")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeptId = new SelectList(db.Departments, "DeptId", "DeptCode", student.DeptId);
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public JsonResult StudentEmailExits(string email)
        {
            var aStudent = db.Students.FirstOrDefault(x => x.Email == email);
            if (aStudent == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllStudents()
        {
            var allStudents = db.Students.ToList();
            return Json(allStudents, JsonRequestBehavior.AllowGet);
        }
    }
}
