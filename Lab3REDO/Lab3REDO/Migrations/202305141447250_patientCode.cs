namespace Lab3REDO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class patientCode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "PatientCode", c => c.String(maxLength: 5));
            AlterColumn("dbo.Patients", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "Name", c => c.String());
            DropColumn("dbo.Patients", "PatientCode");
        }
    }
}
