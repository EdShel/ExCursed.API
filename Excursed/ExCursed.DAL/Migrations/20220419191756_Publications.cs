using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExCursed.DAL.Migrations
{
    public partial class Publications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Publication",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Added = table.Column<DateTimeOffset>(nullable: false),
                    Modified = table.Column<DateTimeOffset>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publication", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publication_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PublicationGroup",
                columns: table => new
                {
                    PublicationId = table.Column<int>(nullable: false),
                    GroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicationGroup", x => new { x.PublicationId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_PublicationGroup_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PublicationGroup_Publication_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Publication",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PublicationMaterial",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PublicationId = table.Column<int>(nullable: false),
                    FileName = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicationMaterial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicationMaterial_Publication_PublicationId",
                        column: x => x.PublicationId,
                        principalTable: "Publication",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AEFE1C5-C5F0-4399-8FB8-420813567554",
                column: "ConcurrencyStamp",
                value: "4697ad62-d62f-4033-8d07-8c1d55c31ebf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C",
                column: "ConcurrencyStamp",
                value: "4103e2f7-d9fc-48d2-840b-e81191983a8f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "828A3B02-77C0-45C1-8E97-6ED57711E577",
                column: "ConcurrencyStamp",
                value: "21e2d8c8-5290-4854-b927-2d0f4b64a699");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99DA7670-5471-414F-834E-9B3A6B6C8F6F",
                column: "ConcurrencyStamp",
                value: "38df7b04-533b-4447-a7f6-30b79ccb8d3e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00CA41A9-C962-4230-937E-D5F54772C062",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa1bfb2f-f84a-4642-bcce-c5d20d7ff3f4", "AQAAAAEAACcQAAAAEO2CEXsK5TmhRX4gLqaszu+nGbjDgX+7IJI7xfliJ3Gqg8ivoU+mED7PA9LV2/kLHQ==", "9badf62a-457d-409f-9df6-3cbbc3f3069b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "74989c6c-0ab7-42eb-b598-80017c167d05", "AQAAAAEAACcQAAAAENw77wbJP6vKZaGdtVmUDPd64TKbHGrWKKG9zgOzxzJ9VoH9tAe53jUWJRfPo4hHiQ==", "e9dfb528-952f-4757-92d6-d1a90b246cf2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b1b9dded-4d6b-4354-bdff-207bea67a67c", "AQAAAAEAACcQAAAAECbvq5KqJHYigcv38/rErJGm6uvyMuQMXg3kar/blPTdtxfekQMs1xDlYYqBrZQrFw==", "317942df-df3a-41f8-bbbc-b0d748b134c0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E8D13331-62AB-463E-A283-6493B68A3622",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "58157095-37d7-4dff-a6eb-011c97f93fe8", "AQAAAAEAACcQAAAAEHmapP+J9DaFlAa4TIgiB3Yxye58erEWR5ZZAzetFFF+0vL9KBW/tGUORQ6ZvqL+1Q==", "3ed3cb18-c0fe-4d39-af29-021d29dcab33" });

            migrationBuilder.CreateIndex(
                name: "IX_Publication_CourseId",
                table: "Publication",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicationGroup_GroupId",
                table: "PublicationGroup",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicationMaterial_PublicationId",
                table: "PublicationMaterial",
                column: "PublicationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PublicationGroup");

            migrationBuilder.DropTable(
                name: "PublicationMaterial");

            migrationBuilder.DropTable(
                name: "Publication");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AEFE1C5-C5F0-4399-8FB8-420813567554",
                column: "ConcurrencyStamp",
                value: "abd8293c-5007-4749-b101-a7ca10d91e9c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C",
                column: "ConcurrencyStamp",
                value: "be32e3f3-363e-4dc0-a4d0-e66f7193b70b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "828A3B02-77C0-45C1-8E97-6ED57711E577",
                column: "ConcurrencyStamp",
                value: "8c95341d-3507-4021-a131-e58252fa48be");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99DA7670-5471-414F-834E-9B3A6B6C8F6F",
                column: "ConcurrencyStamp",
                value: "872f98b6-a513-4c87-9cb7-31a0b56d542f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00CA41A9-C962-4230-937E-D5F54772C062",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a26a1be5-a103-4e8b-8d13-a6a23e585d0e", "AQAAAAEAACcQAAAAEOf+3JrEIi60CGWFiLTGSsP1rmxPRxn+tbuQIJVyGxO7ZAnr+FBAg0uK2Wcm4PEnqw==", "de5eca2f-8f7a-4061-8273-ba2c17cb1840" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da0c839e-7ce5-475a-8bf2-60b8edfa6ae5", "AQAAAAEAACcQAAAAEPctDLxgQJ7bNQcMg91oQIXBSm8YxJOrUFvTGNQGYDdgja8pV5RFD8kSjnsHDnfgow==", "c87bee6c-df8e-490a-8f00-49ace9cb68be" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c382e459-25ac-4406-a8f9-df41b31b7dc7", "AQAAAAEAACcQAAAAEDYgYTRwgHeumuDBLv/0LPO7Sa2V+MW2lEOj0BfShs7AvCM8MwxSwdiIIUJXz59TMg==", "0483845e-7bbe-4a84-86b2-c516a68ccba1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E8D13331-62AB-463E-A283-6493B68A3622",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8317d3ef-7641-4c38-9c02-c6ba74839e9e", "AQAAAAEAACcQAAAAEMQLj28p+8n5q5R1FTb5a+yZSBs8Q8DADKwATs09o/pBVzYlAXFnvxx3J88ifqvi1A==", "0aac2288-ea39-473f-9647-765487e5cd05" });
        }
    }
}
