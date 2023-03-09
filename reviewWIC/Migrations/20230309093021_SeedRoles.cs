using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace reviewWIC.Migrations
{
    public partial class SeedRoles : Migration
    {
        private string DataAdminRoleId = Guid.NewGuid().ToString();
        private string UserRoleId = Guid.NewGuid().ToString();
        private string SysAdminRoleId = Guid.NewGuid().ToString();

        private string User1Id = Guid.NewGuid().ToString();
        private string User2Id = Guid.NewGuid().ToString();

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            SeedRolesSQL(migrationBuilder);

            SeedUser(migrationBuilder);

            SeedUserRoles(migrationBuilder);
        }

        private void SeedRolesSQL(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            VALUES ('{SysAdminRoleId}', 'System Administrator', 'System Administrator', null);");
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            VALUES ('{DataAdminRoleId}', 'Data Administrator', 'Data Administrator', null);");
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            VALUES ('{UserRoleId}', 'User', 'USER', null);");
        }

        private void SeedUser(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @$"INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [Surname], [UserName], [NormalizedUserName], 
[Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], 
[PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IDNumber], [DateOfBirth], [CellNumber], [Address], [Province], [CurrentlyEmployed]) 
VALUES 
(N'{User1Id}', N'Test 2', N'Lastname', N'test2@test.ca', N'TEST2@TEST.CA', 
N'test2@test.ca', N'TEST2@TEST.CA', 0, 
N'AQAAAAEAACcQAAAAEDGQ5wwj6Iz0lXHIZ5IwuvgSO88jrSBT1etWcDYjJN5CBNDKvddZcEeixYBYmcdFag==', 
N'YUPAFWNGZI2UC5FOITC7PX5J7XZTAZAA', N'8e150555-a20d-4610-93ff-49c5af44f749', NULL, 0, 0, NULL, 1, 0, '12331232', '1992-09-16', 'CellNumber', 'Address', 'Province', 1)");

            migrationBuilder.Sql(
                @$"INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [Surname], [UserName], [NormalizedUserName], 
[Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], 
[PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [IDNumber], [DateOfBirth], [CellNumber], [Address], [Province], [CurrentlyEmployed]) 
VALUES 
(N'{User2Id}', N'Test 3', N'Lastname', N'test3@test.ca', N'TEST3@TEST.CA', 
N'test3@test.ca', N'TEST3@TEST.CA', 0, 
N'AQAAAAEAACcQAAAAEDGQ5wwj6Iz0lXHIZ5IwuvgSO88jrSBT1etWcDYjJN5CBNDKvddZcEeixYBYmcdFag==', 
N'YUPAFWNGZI2UC5FOITC7PX5J7XZTAZAA', N'8e150555-a20d-4610-93ff-49c5af44f749', NULL, 0, 0, NULL, 1, 0, '123123123', '1992-08-16', 'CellNumber', 'Address', 'Province', 1)");
        }

        private void SeedUserRoles(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@$"
        INSERT INTO [dbo].[AspNetUserRoles]
           ([UserId]
           ,[RoleId])
        VALUES
           ('{User1Id}', '{DataAdminRoleId}');
        INSERT INTO [dbo].[AspNetUserRoles]
           ([UserId]
           ,[RoleId])
        VALUES
           ('{User1Id}', '{UserRoleId}');");

            migrationBuilder.Sql(@$"
        INSERT INTO [dbo].[AspNetUserRoles]
           ([UserId]
           ,[RoleId])
        VALUES
           ('{User2Id}', '{SysAdminRoleId}');
        INSERT INTO [dbo].[AspNetUserRoles]
           ([UserId]
           ,[RoleId])
        VALUES
           ('{User2Id}', '{DataAdminRoleId}');");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
