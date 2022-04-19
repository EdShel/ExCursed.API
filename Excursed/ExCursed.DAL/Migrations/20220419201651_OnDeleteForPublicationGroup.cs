using Microsoft.EntityFrameworkCore.Migrations;

namespace ExCursed.DAL.Migrations
{
    public partial class OnDeleteForPublicationGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PublicationGroup_Publication_GroupId",
                table: "PublicationGroup");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AEFE1C5-C5F0-4399-8FB8-420813567554",
                column: "ConcurrencyStamp",
                value: "2394cd90-12bd-40a6-b056-24d8d6147542");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C",
                column: "ConcurrencyStamp",
                value: "a3864534-a408-4860-9ba3-db2fc99587fb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "828A3B02-77C0-45C1-8E97-6ED57711E577",
                column: "ConcurrencyStamp",
                value: "541db318-554b-4e24-80e5-12e5d0a03f6d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99DA7670-5471-414F-834E-9B3A6B6C8F6F",
                column: "ConcurrencyStamp",
                value: "56f0dad0-077f-4452-8094-f47b36ec1b0b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00CA41A9-C962-4230-937E-D5F54772C062",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd26c7e6-a0d3-4236-9255-64f37f350eff", "AQAAAAEAACcQAAAAEK3PyMGjkRvKOCYIp2sQijieIfL/sL4WnrGYbn5aaWz2ophfXWptIyng4/PPpGmjlQ==", "a9121c00-0920-40f8-9901-1ca7a02dd79c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "de25fbba-9ddb-4c35-897f-cd686e7e2159", "AQAAAAEAACcQAAAAEO21om+hlrzoBZ8Wao0x3kwroYo08erDIY/c+azbWPKYOsKJTA0ODKTMswcfFoDdFw==", "e28f0f58-73b5-4a37-a339-cde767ccd442" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fcabde9b-5890-4106-b0b4-3f41d89c7087", "AQAAAAEAACcQAAAAEO/EyeGYp3K4bIGcGnb1hBz6/dUnit5e5TzTVQDYzRp+skkOCZEE3K+qYvDkj7Ea4A==", "76669700-f539-4594-880d-ceeaa62f85dd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E8D13331-62AB-463E-A283-6493B68A3622",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "88b5b274-dc18-47d3-8437-a30bebbfa9bc", "AQAAAAEAACcQAAAAEDnNMRJHnG8VZ5QUbta8vX2621Hft0RCiVz0Nm21hWxI4vGlznPoofRVQd+MeT6ZsQ==", "29a8327c-03b7-45e2-983b-fdbd584c5891" });

            migrationBuilder.AddForeignKey(
                name: "FK_PublicationGroup_Publication_PublicationId",
                table: "PublicationGroup",
                column: "PublicationId",
                principalTable: "Publication",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PublicationGroup_Publication_PublicationId",
                table: "PublicationGroup");

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

            migrationBuilder.AddForeignKey(
                name: "FK_PublicationGroup_Publication_GroupId",
                table: "PublicationGroup",
                column: "GroupId",
                principalTable: "Publication",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
