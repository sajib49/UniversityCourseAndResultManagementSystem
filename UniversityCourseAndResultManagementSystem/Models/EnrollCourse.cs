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

        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public DateTime Date { get; set; }

    }
}