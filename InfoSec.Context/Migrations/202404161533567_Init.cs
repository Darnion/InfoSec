namespace InfoSec.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        DayNumber = c.Int(nullable: false),
                        StartTime = c.Time(nullable: false, precision: 7),
                        ModeratorId = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.ModeratorId)
                .Index(t => t.ModeratorId)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        StartDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DayLasting = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        WinnerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.WinnerId)
                .Index(t => t.CityId)
                .Index(t => t.WinnerId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        BirthDate = c.DateTimeOffset(nullable: false, precision: 7),
                        CountryId = c.Int(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ImagePath = c.String(nullable: false),
                        GenderId = c.Int(nullable: false),
                        DirectionId = c.Int(),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.Directions", t => t.DirectionId)
                .ForeignKey("dbo.Genders", t => t.GenderId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.CountryId)
                .Index(t => t.GenderId)
                .Index(t => t.DirectionId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        TitleEnglish = c.String(nullable: false),
                        CodeLetter = c.String(nullable: false),
                        CodeDigital = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Directions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserActivities",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Activity_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Activity_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Activities", t => t.Activity_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Activity_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Users", "GenderId", "dbo.Genders");
            DropForeignKey("dbo.Events", "WinnerId", "dbo.Users");
            DropForeignKey("dbo.Users", "DirectionId", "dbo.Directions");
            DropForeignKey("dbo.Users", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Activities", "ModeratorId", "dbo.Users");
            DropForeignKey("dbo.UserActivities", "Activity_Id", "dbo.Activities");
            DropForeignKey("dbo.UserActivities", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Events", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Activities", "EventId", "dbo.Events");
            DropIndex("dbo.UserActivities", new[] { "Activity_Id" });
            DropIndex("dbo.UserActivities", new[] { "User_Id" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Users", new[] { "DirectionId" });
            DropIndex("dbo.Users", new[] { "GenderId" });
            DropIndex("dbo.Users", new[] { "CountryId" });
            DropIndex("dbo.Events", new[] { "WinnerId" });
            DropIndex("dbo.Events", new[] { "CityId" });
            DropIndex("dbo.Activities", new[] { "EventId" });
            DropIndex("dbo.Activities", new[] { "ModeratorId" });
            DropTable("dbo.UserActivities");
            DropTable("dbo.Roles");
            DropTable("dbo.Genders");
            DropTable("dbo.Directions");
            DropTable("dbo.Countries");
            DropTable("dbo.Users");
            DropTable("dbo.Cities");
            DropTable("dbo.Events");
            DropTable("dbo.Activities");
        }
    }
}
