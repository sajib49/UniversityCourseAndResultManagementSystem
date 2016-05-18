using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagementSystem.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }

        [Display(Name="Room No.")]
        public string RoomNo { get; set; }

    }
}