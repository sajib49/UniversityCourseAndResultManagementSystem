using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityCourseAndResultManagementSystem.Models
{
    public class Student
    {
        [Key]
        [Display(Name = "Student")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Student name is required!")]
        [Display(Name = "Student Name")]
        public string StudentName { get; set; }


        [Required(ErrorMessage = "Student email address is required!")]
        [EmailAddress(ErrorMessage = "Invalid Email Address"),StringLength(50)]
        [Remote("StudentEmailExits","Students",ErrorMessage = "Email already exits.Try with another email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Student contact no is required!")]
        [Display(Name = "Contact No")]
        public string ContactNo { get; set; }

        [Display(Name = "Date")]
        [Required(ErrorMessage = "Registration date is required!")]
        public DateTime RegDate { get; set; }

        [Display(Name = "Address")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Student address is required!")]
        public string Address { get; set; }

        [Display(Name = "Department")]
        public int DeptId { get; set; }

        [Display(Name = "Registration Number")]
        //[Required]
        public string RegNo { get; set; }

        [ForeignKey("DeptId")]
        public virtual Department Department { get; set; }




    }
}