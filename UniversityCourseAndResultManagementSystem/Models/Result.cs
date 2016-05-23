using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagementSystem.Models
{
    public class Result
    {
        [Key]
        public int ResultId { get; set; }

        [Required(ErrorMessage = "Please Select Student")]
        [Display(Name = "Student")]
        public int StudentId { get; set; }

        [Display(Name = "Course")]
        [Required(ErrorMessage = "Please Select Course")]
        public int CourseId { get; set; }


        [Display(Name = "Grade")]
        [Required(ErrorMessage = "Please Select Grade")]
        public string Grade { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
    }
}