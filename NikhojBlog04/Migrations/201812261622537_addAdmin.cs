namespace NikhojBlog04.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAdmin : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Name], [Phone], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [LostPersonPost_id]) VALUES (N'338759f7-aef4-4624-84c4-c4a242965453', N'Tanvir', N'01554035483', N'tanvir8212@gmail.com', 0, N'ALqgKxxbrcfyYnykQsvIFTjaUWlHy4gxOhJe2CKev9OqdrayqKrjzHU0SppXF6BW1w==', N'a5d4524d-c1ad-4140-9ea0-7490d38f6cb3', NULL, 0, 0, NULL, 1, 0, N'tanvir8212@gmail.com', NULL)
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Name], [Phone], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [LostPersonPost_id]) VALUES (N'9d3d4db9-d3f5-4f3b-b3d6-85d736661f5c', N'Tanvir Mahmud Khan', N'01554035483', N'admin@nikhoj.com', 0, N'AMUeXZiheXvHZpmocNAA0/OitIk9NTcZyez9CYrbXvF3JB9RpilAsImUYn33fh682g==', N'a70a2071-2919-4cd8-af72-e77b0a80d4ec', NULL, 0, 0, NULL, 1, 0, N'admin@nikhoj.com', NULL)
            
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'70af839b-3969-4f89-b104-3820169deb6c', N'Admin')

            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9d3d4db9-d3f5-4f3b-b3d6-85d736661f5c', N'70af839b-3969-4f89-b104-3820169deb6c')

");
        }
        
        public override void Down()
        {
        }
    }
}
