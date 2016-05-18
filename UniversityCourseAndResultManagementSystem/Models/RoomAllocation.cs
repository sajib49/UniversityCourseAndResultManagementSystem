using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagementSystem.Models
{
    public class RoomAllocation
    {
        [Key]
        public int RoomAllocationId { get; set; }

        [Display(Name="Department")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }


        [Display(Name="Course")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }


        [Display(Name = "Room")]
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }


        [Display(Name = "Name")]
        public int DayId { get; set; }


        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }
    }
}