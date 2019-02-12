namespace ProektnaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tipsters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Picks", "TipsterId");
            AddForeignKey("dbo.Picks", "TipsterId", "dbo.Tipsters", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Picks", "TipsterId", "dbo.Tipsters");
            DropIndex("dbo.Picks", new[] { "TipsterId" });
            DropTable("dbo.Tipsters");
        }
    }
}
