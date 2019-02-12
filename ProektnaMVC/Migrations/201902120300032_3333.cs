namespace ProektnaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3333 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Picks", "Result", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Picks", "Result", c => c.String());
        }
    }
}
