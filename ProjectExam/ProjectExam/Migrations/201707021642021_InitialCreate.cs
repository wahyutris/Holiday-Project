namespace ProjectExam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LeaderBoards",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        ExamID = c.Int(),
                        Score = c.Int(nullable: false),
                        Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserName);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LeaderBoards");
        }
    }
}
