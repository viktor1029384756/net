namespace Lab3REDO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class doctorHospital2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "Hospital_Id1", c => c.Int());
            AddColumn("dbo.Hospitals", "Doctor_Id", c => c.Int());
            CreateIndex("dbo.Doctors", "Hospital_Id1");
            CreateIndex("dbo.Hospitals", "Doctor_Id");
            AddForeignKey("dbo.Doctors", "Hospital_Id1", "dbo.Hospitals", "Id");
            AddForeignKey("dbo.Hospitals", "Doctor_Id", "dbo.Doctors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Hospitals", "Doctor_Id", "dbo.Doctors");
            DropForeignKey("dbo.Doctors", "Hospital_Id1", "dbo.Hospitals");
            DropIndex("dbo.Hospitals", new[] { "Doctor_Id" });
            DropIndex("dbo.Doctors", new[] { "Hospital_Id1" });
            DropColumn("dbo.Hospitals", "Doctor_Id");
            DropColumn("dbo.Doctors", "Hospital_Id1");
        }
    }
}
