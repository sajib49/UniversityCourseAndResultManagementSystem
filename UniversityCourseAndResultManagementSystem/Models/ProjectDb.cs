using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagementSystem.Models
{
    public class ProjectDb:DbContext
    {
        public ProjectDb() : base("UCRMS_ConnectionString")
        {
            
        }
        public DbSet<Department> Departments { get; set; }
        
    }
}