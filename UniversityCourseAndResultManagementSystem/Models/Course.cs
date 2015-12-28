using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagementSystem.Models
{
    public class Course
    {
        [Display(Name = "Course")]
        public int CourseId { get; set; }

        [Display(Name = "Course Code")]
        [Required(ErrorMessage = "Course code is required")]
        [MinLength(5, ErrorMessage = "Use minimum 5 character")]
        public string CourseCode { get; set; }

        [Display(Name = "Course Name")]
        [Required(ErrorMessage = "Course Name is required")]
        public string CourseName { get; set; }

        [Display(Name = "Course Creadit")]
        [Required(ErrorMessage = "Course name is required"), Range(0.5, 5.0, ErrorMessage = "Creadit must be between 0.5 to 5.0")]
        public double Creadit { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Course description is required")]
        public string Description { get; set; }

        [Display(Name = "Department")]
        public int DeptId { get; set; }

        [Display(Name = "Semester")]
        public int SemesterId { get; set; }

        [ForeignKey("DeptId")]
        public virtual Department Department { get; set; }

        [ForeignKey("SemesterId")]
        public virtual Semester Semester { get; set; }
    }
}