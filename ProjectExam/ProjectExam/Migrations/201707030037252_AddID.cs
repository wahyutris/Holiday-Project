namespace ProjectExam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddID : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.LeaderBoards");
            AddColumn("dbo.LeaderBoards", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.LeaderBoards", "UserName", c => c.String());
            AddPrimaryKey("dbo.LeaderBoards", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.LeaderBoards");
            AlterColumn("dbo.LeaderBoards", "UserName", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.LeaderBoards", "ID");
            AddPrimaryKey("dbo.LeaderBoards", "UserName");
        }
    }
}
