using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagementSystem.Models
{
    public class Designation
    {   
        [Key]
        [Display(Name = "Designation")]
        public int DesignationId { get; set; }

        [Display(Name = "Designation Name")]
        public string DesignationName { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; } 
    }
}