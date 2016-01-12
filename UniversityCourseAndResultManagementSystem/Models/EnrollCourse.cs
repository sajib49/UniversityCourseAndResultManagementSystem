using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagementSystem.Models
{
    public class EnrollCourse
    {
        [Key]
        public int EnrollId { get; set; }

        [Display(Name = "Student Reg. No")]
        public int StudentId { get; set; }

        public int CourseId { get; set; }

        [DataType(DataType.Date,ErrorMessage = "Invalid date formate")]
        public DateTime EnrollDate { get; set; }

    }
}