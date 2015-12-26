using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagementSystem.Models
{
   
    public class Department
    {
        
        [Key]
        [Display(Name = "Department")]
        public int DeptId { get; set; }

        [Display(Name = "Department Code")]
        [Required(ErrorMessage = "Please Enter Department Code"), MinLength(2, ErrorMessage = "Use minimum two character"), MaxLength(7, ErrorMessage = "Maximum seven character is permited")]
        public string DeptCode { get; set; }

        [Display(Name = "Depertment Code")]
        [Required(ErrorMessage = "Please Enter Department Name")]
        public string DeptName { get; set; }

        public virtual ICollection<Course> Courses { get; set; } 


    }
}