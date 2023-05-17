namespace Lab3REDO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Patients", "Doctor_Id", "dbo.Doctors");
            DropIndex("dbo.Patients", new[] { "Doctor_Id" });
            CreateTable(
                "dbo.PatientDoctors",
                c => new
                    {
                        Patient_Id = c.Int(nullable: false),
                        Doctor_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Patient_Id, t.Doctor_Id })
                .ForeignKey("dbo.Patients", t => t.Patient_Id, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.Doctor_Id, cascadeDelete: true)
                .Index(t => t.Patient_Id)
                .Index(t => t.Doctor_Id);
            
            DropColumn("dbo.Patients", "Doctor_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "Doctor_Id", c => c.Int());
            DropForeignKey("dbo.PatientDoctors", "Doctor_Id", "dbo.Doctors");
            DropForeignKey("dbo.PatientDoctors", "Patient_Id", "dbo.Patients");
            DropIndex("dbo.PatientDoctors", new[] { "Doctor_Id" });
            DropIndex("dbo.PatientDoctors", new[] { "Patient_Id" });
            DropTable("dbo.PatientDoctors");
            CreateIndex("dbo.Patients", "Doctor_Id");
            AddForeignKey("dbo.Patients", "Doctor_Id", "dbo.Doctors", "Id");
        }
    }
}
