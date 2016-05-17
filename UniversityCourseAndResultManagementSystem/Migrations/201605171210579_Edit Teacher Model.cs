namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditTeacherModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "RemaingCreadit", c => c.Double(nullable: false));
            AlterColumn("dbo.Teachers", "TeacherName", c => c.String(nullable: false));
            AlterColumn("dbo.Teachers", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Teachers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Teachers", "ContactNo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teachers", "ContactNo", c => c.String());
            AlterColumn("dbo.Teachers", "Email", c => c.String());
            AlterColumn("dbo.Teachers", "Address", c => c.String());
            AlterColumn("dbo.Teachers", "TeacherName", c => c.String());
            DropColumn("dbo.Teachers", "RemaingCreadit");
        }
    }
}
