namespace DeathValley.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Created_Tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CacheDatas",
                c => new
                    {
                        CacheDataId = c.Int(nullable: false, identity: true),
                        PointX = c.Double(nullable: false),
                        PointY = c.Double(nullable: false),
                        ParamId = c.Int(),
                    })
                .PrimaryKey(t => t.CacheDataId)
                .ForeignKey("dbo.Params", t => t.ParamId)
                .Index(t => t.ParamId);
            
            CreateTable(
                "dbo.Params",
                c => new
                    {
                        ParamId = c.Int(nullable: false, identity: true),
                        CoefficientA = c.Double(nullable: false),
                        CoefficientB = c.Double(nullable: false),
                        CoefficientC = c.Double(nullable: false),
                        Step = c.Double(nullable: false),
                        RangeFrom = c.Double(nullable: false),
                        RangeTo = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ParamId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CacheDatas", "ParamId", "dbo.Params");
            DropIndex("dbo.CacheDatas", new[] { "ParamId" });
            DropTable("dbo.Params");
            DropTable("dbo.CacheDatas");
        }
    }
}
