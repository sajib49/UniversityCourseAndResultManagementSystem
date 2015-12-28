using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagementSystem.Models
{
    public class Teacher
    {
        [Key]
        [Display(Name = "Teacher")]
        public int TeacherId { get; set; }

        [Display(Name = "Teacher Name")]
        public string TeacherName { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Contact No")]
        public string ContactNo { get; set; }

        public int DesignationId { get; set; }

        public int DeptId { get; set; }

        [Range(0.5,double.MaxValue,ErrorMessage = "Creadit can be negative")]
        [Display(Name = "Creadit To Be Taken")]
        public double CreaditToBeTaken { set; get; }

        [ForeignKey("DesignationId")]
        public virtual Designation Designation { get; set; }

        [ForeignKey("DeptId")]
        public virtual Department Department { get; set; }
    }
}