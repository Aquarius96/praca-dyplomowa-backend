using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PracaDyplomowaBackend.Repo.Migrations
{
    public partial class CosmeticChangesAndFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Added",
                table: "WantedBooks");

            migrationBuilder.DropColumn(
                name: "Added",
                table: "CurrentlyReadBooks");

            migrationBuilder.RenameColumn(
                name: "PasswordSalt",
                table: "Users",
                newName: "PhotoUrl");

            migrationBuilder.RenameColumn(
                name: "Added",
                table: "ReadBooks",
                newName: "Finished");

            migrationBuilder.AlterColumn<Guid>(
                name: "ConfirmationCode",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "PhotoUrl",
                table: "Users",
                newName: "PasswordSalt");

            migrationBuilder.RenameColumn(
                name: "Finished",
                table: "ReadBooks",
                newName: "Added");

            migrationBuilder.AddColumn<DateTime>(
                name: "Added",
                table: "WantedBooks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "ConfirmationCode",
                table: "Users",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<DateTime>(
                name: "Added",
                table: "CurrentlyReadBooks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
