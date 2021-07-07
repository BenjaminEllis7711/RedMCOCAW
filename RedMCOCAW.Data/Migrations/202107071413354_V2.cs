namespace RedMCOCAW.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Roster", "NodeId", "dbo.Node");
            DropForeignKey("dbo.NodeRoster", new[] { "Roster_MemberId", "Roster_ChampionId" }, "dbo.Roster");
            DropIndex("dbo.Roster", new[] { "NodeId" });
            DropPrimaryKey("dbo.Roster");
            CreateTable(
                "dbo.NodeRoster",
                c => new
                    {
                        NodeId = c.Int(nullable: false),
                        NodeAssignmentId = c.Int(nullable: false),
                        Roster_MemberId = c.Int(),
                        Roster_ChampionId = c.Int(),
                    })
                .PrimaryKey(t => new { t.NodeId, t.NodeAssignmentId })
                .ForeignKey("dbo.Node", t => t.NodeId, cascadeDelete: true)
                .ForeignKey("dbo.Roster", t => new { t.Roster_MemberId, t.Roster_ChampionId })
                .Index(t => t.NodeId)
                .Index(t => new { t.Roster_MemberId, t.Roster_ChampionId });
            
            AddColumn("dbo.Roster", "NodeAssignmentId", c => c.Int());
            AddColumn("dbo.Champion", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Node", "OwnerId", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Roster", new[] { "MemberId", "ChampionId" });
            DropColumn("dbo.Roster", "NodeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Roster", "NodeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.NodeRoster", new[] { "Roster_MemberId", "Roster_ChampionId" }, "dbo.Roster");
            DropForeignKey("dbo.NodeRoster", "NodeId", "dbo.Node");
            DropIndex("dbo.NodeRoster", new[] { "Roster_MemberId", "Roster_ChampionId" });
            DropIndex("dbo.NodeRoster", new[] { "NodeId" });
            DropPrimaryKey("dbo.Roster");
            DropColumn("dbo.Node", "OwnerId");
            DropColumn("dbo.Champion", "OwnerId");
            DropColumn("dbo.Roster", "NodeAssignmentId");
            DropTable("dbo.NodeRoster");
            AddPrimaryKey("dbo.Roster", new[] { "MemberId", "ChampionId", "NodeId" });
            CreateIndex("dbo.Roster", "NodeId");
            AddForeignKey("dbo.NodeRoster", new[] { "Roster_MemberId", "Roster_ChampionId" }, "dbo.Roster", new[] { "MemberId", "ChampionId" });
            AddForeignKey("dbo.Roster", "NodeId", "dbo.Node", "NodeId", cascadeDelete: true);
        }
    }
}
