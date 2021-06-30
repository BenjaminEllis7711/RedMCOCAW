namespace RedMCOCAW.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Alliance", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Member", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Roster", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Roster", "OwnerId");
            DropColumn("dbo.Member", "OwnerId");
            DropColumn("dbo.Alliance", "OwnerId");
        }
    }
}
