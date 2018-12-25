namespace NikhojBlog04.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Table_Added_LostPersonPosts_Comments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false),
                        dateTime = c.DateTime(nullable: false),
                        lostPersonPost_id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.LostPersonPosts", t => t.lostPersonPost_id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.lostPersonPost_id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.LostPersonPosts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        LostPersonName = c.String(nullable: false),
                        LostPersonAge = c.Int(nullable: false),
                        ContactName = c.String(nullable: false),
                        ContactAddress = c.String(nullable: false),
                        ContactPhone = c.String(nullable: false),
                        PostType = c.String(nullable: false),
                        Details = c.String(nullable: false),
                        ImageDatas = c.Binary(),
                        dateTime = c.DateTime(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.AspNetUsers", "LostPersonPost_id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "LostPersonPost_id");
            AddForeignKey("dbo.AspNetUsers", "LostPersonPost_id", "dbo.LostPersonPosts", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.LostPersonPosts", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "LostPersonPost_id", "dbo.LostPersonPosts");
            DropForeignKey("dbo.Comments", "lostPersonPost_id", "dbo.LostPersonPosts");
            DropIndex("dbo.AspNetUsers", new[] { "LostPersonPost_id" });
            DropIndex("dbo.LostPersonPosts", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "lostPersonPost_id" });
            DropColumn("dbo.AspNetUsers", "LostPersonPost_id");
            DropTable("dbo.LostPersonPosts");
            DropTable("dbo.Comments");
        }
    }
}
