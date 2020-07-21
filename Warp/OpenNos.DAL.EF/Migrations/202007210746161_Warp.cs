namespace OpenNos.DAL.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Warp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WarpPoint",
                c => new
                    {
                        WarpPointID = c.Short(nullable: false, identity: true),
                        Index = c.Short(nullable: false),
                        Name = c.String(maxLength: 255),
                        Authority = c.Short(nullable: false),
                        MapId = c.Short(nullable: false),
                        MapX = c.Short(nullable: false),
                        MapY = c.Short(nullable: false),
                        IsInstance = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.WarpPointID)
                .ForeignKey("dbo.Map", t => t.MapId)
                .Index(t => t.MapId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WarpPoint", "MapId", "dbo.Map");
            DropIndex("dbo.WarpPoint", new[] { "MapId" });
            DropTable("dbo.WarpPoint");
        }
    }
}
