namespace Lab3REDO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nova : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Doctors", "Hospital_Id", "dbo.Hospitals");
            DropForeignKey("dbo.Doctors", "Hospital_Id1", "dbo.Hospitals");
            DropForeignKey("dbo.Hospitals", "Doctor_Id", "dbo.Doctors");
            DropIndex("dbo.Doctors", new[] { "Hospital_Id" });
            DropIndex("dbo.Doctors", new[] { "Hospital_Id1" });
            DropIndex("dbo.Hospitals", new[] { "Doctor_Id" });
            CreateTable(
                "dbo.HospitalDoctors",
                c => new
                    {
                        Hospital_Id = c.Int(nullable: false),
                        Doctor_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Hospital_Id, t.Doctor_Id })
                .ForeignKey("dbo.Hospitals", t => t.Hospital_Id, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.Doctor_Id, cascadeDelete: true)
                .Index(t => t.Hospital_Id)
                .Index(t => t.Doctor_Id);
            
            AddColumn("dbo.Doctors", "HospitalId", c => c.Int(nullable: false));
            DropColumn("dbo.Doctors", "Hospital_Id");
            DropColumn("dbo.Doctors", "Hospital_Id1");
            DropColumn("dbo.Hospitals", "Doctor_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Hospitals", "Doctor_Id", c => c.Int());
            AddColumn("dbo.Doctors", "Hospital_Id1", c => c.Int());
            AddColumn("dbo.Doctors", "Hospital_Id", c => c.Int());
            DropForeignKey("dbo.HospitalDoctors", "Doctor_Id", "dbo.Doctors");
            DropForeignKey("dbo.HospitalDoctors", "Hospital_Id", "dbo.Hospitals");
            DropIndex("dbo.HospitalDoctors", new[] { "Doctor_Id" });
            DropIndex("dbo.HospitalDoctors", new[] { "Hospital_Id" });
            DropColumn("dbo.Doctors", "HospitalId");
            DropTable("dbo.HospitalDoctors");
            CreateIndex("dbo.Hospitals", "Doctor_Id");
            CreateIndex("dbo.Doctors", "Hospital_Id1");
            CreateIndex("dbo.Doctors", "Hospital_Id");
            AddForeignKey("dbo.Hospitals", "Doctor_Id", "dbo.Doctors", "Id");
            AddForeignKey("dbo.Doctors", "Hospital_Id1", "dbo.Hospitals", "Id");
            AddForeignKey("dbo.Doctors", "Hospital_Id", "dbo.Hospitals", "Id");
        }
    }
}
