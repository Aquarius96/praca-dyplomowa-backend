using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PracaDyplomowaBackend.Repo.Migrations
{
    public partial class AddConfirmedProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Confirmed",
                table: "Books",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Confirmed",
                table: "BookReviews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Confirmed",
                table: "Authors",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "Added",
                value: new DateTime(2018, 10, 13, 14, 43, 52, 825, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "Added",
                value: new DateTime(2018, 10, 13, 14, 43, 52, 825, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "Added",
                value: new DateTime(2018, 10, 13, 14, 43, 52, 825, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3f38fcb6-fd6e-43c9-d30b-08d6119ae085"),
                column: "Added",
                value: new DateTime(2018, 10, 13, 14, 43, 52, 824, DateTimeKind.Utc));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Confirmed",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Confirmed",
                table: "BookReviews");

            migrationBuilder.DropColumn(
                name: "Confirmed",
                table: "Authors");

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
    }
}
