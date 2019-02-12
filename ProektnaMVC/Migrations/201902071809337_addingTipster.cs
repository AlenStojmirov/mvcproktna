namespace ProektnaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingTipster : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Picks", "TipsterId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Picks", "TipsterId");
        }
    }
}
