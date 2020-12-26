namespace CameraCapture.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class smallchange : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                        FirstName = c.String(maxLength: 100),
                        LastName = c.String(maxLength: 100),
                        Birthday = c.DateTime(),
                        Age = c.Int(nullable: false),
                        AgeType = c.Byte(nullable: false),
                        PatientId = c.String(maxLength: 100),
                        Gender = c.Int(nullable: false),
                        Pregnant = c.Boolean(nullable: false),
                        StudyDescription = c.String(maxLength: 100),
                        Note = c.String(maxLength: 4000),
                        StudyDate = c.DateTime(),
                        Created = c.DateTime(nullable: false),
                        AccessionNumber = c.String(maxLength: 100),
                        RequestingPhysician = c.String(maxLength: 100),
                        NA = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                        FirstName = c.String(maxLength: 100),
                        LastName = c.String(maxLength: 100),
                        Birthday = c.DateTime(),
                        Age = c.Int(nullable: false),
                        AgeType = c.Byte(nullable: false),
                        Username = c.String(nullable: false, maxLength: 15),
                        Password = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Patients");
        }
    }
}
