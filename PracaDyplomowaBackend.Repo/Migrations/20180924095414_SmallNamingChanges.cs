using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PracaDyplomowaBackend.Repo.Migrations
{
    public partial class SmallNamingChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OriginalTitle",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "RoleName",
                table: "Roles",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "GenreName",
                table: "Genres",
                newName: "Name");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "Added",
                value: new DateTime(2018, 9, 24, 9, 54, 13, 458, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "Added",
                value: new DateTime(2018, 9, 24, 9, 54, 13, 458, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "Added",
                value: new DateTime(2018, 9, 24, 9, 54, 13, 458, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3f38fcb6-fd6e-43c9-d30b-08d6119ae085"),
                column: "Added",
                value: new DateTime(2018, 9, 24, 9, 54, 13, 456, DateTimeKind.Utc));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Roles",
                newName: "RoleName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Genres",
                newName: "GenreName");

            migrationBuilder.AddColumn<string>(
                name: "OriginalTitle",
                table: "Books",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Added", "OriginalTitle" },
                values: new object[] { new DateTime(2018, 9, 4, 11, 19, 20, 378, DateTimeKind.Utc), "brak" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Added", "OriginalTitle" },
                values: new object[] { new DateTime(2018, 9, 4, 11, 19, 20, 378, DateTimeKind.Utc), "brak" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Added", "OriginalTitle" },
                values: new object[] { new DateTime(2018, 9, 4, 11, 19, 20, 378, DateTimeKind.Utc), "brak" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3f38fcb6-fd6e-43c9-d30b-08d6119ae085"),
                column: "Added",
                value: new DateTime(2018, 9, 4, 11, 19, 20, 376, DateTimeKind.Utc));
        }
    }
}
