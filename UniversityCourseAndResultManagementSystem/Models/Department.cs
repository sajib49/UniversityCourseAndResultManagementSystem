using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityCourseAndResultManagementSystem.Models
{
   
    public class Department
    {
        
        [Key]
        [Display(Name = "Department")]
        public int DeptId { get; set; }

        [Display(Name = "Department Code")]
        [Required(ErrorMessage = "Please Enter Department Code"), MinLength(2, ErrorMessage = "Use minimum two character"), MaxLength(7, ErrorMessage = "Maximum seven character is permited")]
        [Remote("DepartmentCodeExits","Departments",ErrorMessage = "Department code has been already exits.")]
        public string DeptCode { get; set; }

        [Display(Name = "Depertment Name")]
        [Required(ErrorMessage = "Please Enter Department Name")]
        [Remote("DepartmentNameExits", "Departments", ErrorMessage = "Department name has been already exits.")]
        public string DeptName { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
        public virtual ICollection<Student> Students { get; set; } 


    }
}