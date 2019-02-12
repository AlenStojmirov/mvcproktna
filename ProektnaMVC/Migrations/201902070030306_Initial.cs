namespace ProektnaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Picks",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Sport = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        Game = c.String(nullable: false),
                        Picks = c.String(nullable: false),
                        Odds = c.Single(nullable: false),
                        Stake = c.Int(nullable: false),
                        Bookmaker = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Picks");
        }
    }
}
