using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PracaDyplomowaBackend.Repo.Migrations
{
    public partial class AddAuthorDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmationCode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Confirmed",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Firstname",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Lastname",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Authors",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "Added",
                value: new DateTime(2019, 1, 12, 11, 1, 39, 565, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "Added",
                value: new DateTime(2019, 1, 12, 11, 1, 39, 566, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "Added",
                value: new DateTime(2019, 1, 12, 11, 1, 39, 566, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3f38fcb6-fd6e-43c9-d30b-08d6119ae085"),
                columns: new[] { "Added", "Password" },
                values: new object[] { new DateTime(2019, 1, 12, 11, 1, 39, 564, DateTimeKind.Utc), "AQAAAAEAACcQAAAAELo43AUBrHAT76Rmf5YUHxiy51bN30zu1V7mMPGHIcdHV33n1GtuV0Vh7Hnzn0HqfA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Authors");

            migrationBuilder.AddColumn<Guid>(
                name: "ConfirmationCode",
                table: "Users",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "Confirmed",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Firstname",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lastname",
                table: "Users",
                nullable: true);

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
                columns: new[] { "Added", "Confirmed", "Firstname", "Lastname", "Password" },
                values: new object[] { new DateTime(2018, 10, 13, 14, 43, 52, 824, DateTimeKind.Utc), true, "Marcin", "Zapadka", "AQAAAAEAACcQAAAAELFL9kOX6RSdfEY6XayG8rRXip7ST1br7qyVmlRQ4wlaiFGAQDyzpvUsh9mAH1RdLg==" });
        }
    }
}
