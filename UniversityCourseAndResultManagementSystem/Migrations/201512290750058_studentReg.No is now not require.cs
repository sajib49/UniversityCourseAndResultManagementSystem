namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentRegNoisnownotrequire : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "RegNo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "RegNo", c => c.String(nullable: false));
        }
    }
}
