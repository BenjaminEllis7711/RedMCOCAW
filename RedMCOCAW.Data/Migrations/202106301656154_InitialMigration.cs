namespace RedMCOCAW.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alliance",
                c => new
                    {
                        AllianceId = c.Int(nullable: false, identity: true),
                        AllianceTag = c.String(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.AllianceId);
            
            CreateTable(
                "dbo.Member",
                c => new
                    {
                        MemberId = c.Int(nullable: false, identity: true),
                        AllianceId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.MemberId)
                .ForeignKey("dbo.Alliance", t => t.AllianceId, cascadeDelete: true)
                .Index(t => t.AllianceId);
            
            CreateTable(
                "dbo.Champion",
                c => new
                    {
                        ChampId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ChampId);
            
            CreateTable(
                "dbo.Node",
                c => new
                    {
                        NodeId = c.Int(nullable: false, identity: true),
                        Details = c.String(),
                    })
                .PrimaryKey(t => t.NodeId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Roster",
                c => new
                    {
                        MemberId = c.Int(nullable: false),
                        ChampionId = c.Int(nullable: false),
                        NodeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MemberId, t.ChampionId, t.NodeId })
                .ForeignKey("dbo.Champion", t => t.ChampionId, cascadeDelete: true)
                .ForeignKey("dbo.Member", t => t.MemberId, cascadeDelete: true)
                .ForeignKey("dbo.Node", t => t.NodeId, cascadeDelete: true)
                .Index(t => t.MemberId)
                .Index(t => t.ChampionId)
                .Index(t => t.NodeId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.Roster", "NodeId", "dbo.Node");
            DropForeignKey("dbo.Roster", "MemberId", "dbo.Member");
            DropForeignKey("dbo.Roster", "ChampionId", "dbo.Champion");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Member", "AllianceId", "dbo.Alliance");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Roster", new[] { "NodeId" });
            DropIndex("dbo.Roster", new[] { "ChampionId" });
            DropIndex("dbo.Roster", new[] { "MemberId" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Member", new[] { "AllianceId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Roster");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Node");
            DropTable("dbo.Champion");
            DropTable("dbo.Member");
            DropTable("dbo.Alliance");
        }
    }
}
