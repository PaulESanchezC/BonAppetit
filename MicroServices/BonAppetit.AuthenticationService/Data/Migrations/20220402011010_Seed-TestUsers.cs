using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class SeedTestUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"

                INSERT INTO [dbo].[AspNetUsers] ([Id], [FristName], [LastName], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'8ee0db69-620b-48db-b96f-d9bf705ded27', N'Client Test #1', N'Client Test #1', N'TestClient@email.com', N'TESTCLIENT@EMAIL.COM', N'TestClient@email.com', N'TESTCLIENT@EMAIL.COM', 0, NULL, N'HPWXJ2NLD5PNWKZZR7HBHVFQOGTUXWCM', N'11a2324d-12e1-4767-a65e-508365f03cf9', N'514 001 Clnt', 0, 0, NULL, 1, 0)
                INSERT INTO [dbo].[AspNetUsers] ([Id], [FristName], [LastName], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'c5d220ab-8dfd-49d6-bbc9-66015eda915c', N'Restaurant Test #1', N'Restaurant Test #1', N'TestRestaurant@email.com', N'TESTRESTAURANT@EMAIL.COM', N'TestRestaurant@email.com', N'TESTRESTAURANT@EMAIL.COM', 0, NULL, N'KFYYIMCJPOPOH3HPFXTMEO5IKGNGBMI6', N'7728ec4a-f02f-4a83-a31d-e151260b1ebb', N'514 001 Rest', 0, 0, NULL, 1, 0)              
            
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'28d83d48-8a8d-4ea9-87b1-aff593837468', N'manager', N'MANAGER', N'30d9c96c-6f01-497d-99de-00eade1cec08')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'f9de634b-43b3-4516-ba7a-c7d002324f9b', N'client', N'CLIENT', N'441190bc-a213-45a5-850c-648ddfbf5d0e')


                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c5d220ab-8dfd-49d6-bbc9-66015eda915c', N'28d83d48-8a8d-4ea9-87b1-aff593837468')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8ee0db69-620b-48db-b96f-d9bf705ded27', N'f9de634b-43b3-4516-ba7a-c7d002324f9b')

                SET IDENTITY_INSERT [dbo].[AspNetUserClaims] ON
                INSERT INTO [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (1, N'c5d220ab-8dfd-49d6-bbc9-66015eda915c', N'name', N'Restaurant Test #1')
                INSERT INTO [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (2, N'c5d220ab-8dfd-49d6-bbc9-66015eda915c', N'family_name', N'Restaurant Test #1')
                INSERT INTO [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (3, N'c5d220ab-8dfd-49d6-bbc9-66015eda915c', N'phone_number', N'514 001 Rest')
                INSERT INTO [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (4, N'c5d220ab-8dfd-49d6-bbc9-66015eda915c', N'email', N'TestRestaurant@email.com')
                INSERT INTO [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (5, N'c5d220ab-8dfd-49d6-bbc9-66015eda915c', N'role', N'restaurant')
                INSERT INTO [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (6, N'c5d220ab-8dfd-49d6-bbc9-66015eda915c', N'name', N'Restaurant Test #1')
                INSERT INTO [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (7, N'c5d220ab-8dfd-49d6-bbc9-66015eda915c', N'family_name', N'Restaurant Test #1')
                INSERT INTO [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (8, N'c5d220ab-8dfd-49d6-bbc9-66015eda915c', N'phone_number', N'514 001 Rest')
                INSERT INTO [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (9, N'c5d220ab-8dfd-49d6-bbc9-66015eda915c', N'email', N'TestRestaurant@email.com')
                INSERT INTO [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (10, N'c5d220ab-8dfd-49d6-bbc9-66015eda915c', N'role', N'restaurant')
                INSERT INTO [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (11, N'8ee0db69-620b-48db-b96f-d9bf705ded27', N'name', N'Client Test #1')
                INSERT INTO [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (12, N'8ee0db69-620b-48db-b96f-d9bf705ded27', N'family_name', N'Client Test #1')
                INSERT INTO [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (13, N'8ee0db69-620b-48db-b96f-d9bf705ded27', N'phone_number', N'514 001 Clnt')
                INSERT INTO [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (14, N'8ee0db69-620b-48db-b96f-d9bf705ded27', N'email', N'TestClient@email.com')
                INSERT INTO [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (15, N'8ee0db69-620b-48db-b96f-d9bf705ded27', N'role', N'client')
                SET IDENTITY_INSERT [dbo].[AspNetUserClaims] OFF

");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
