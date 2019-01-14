using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PracaDyplomowaBackend.Repo.Migrations
{
    public partial class FinalDbChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorGenres",
                keyColumns: new[] { "GenreId", "AuthorId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AuthorGenres",
                keyColumns: new[] { "GenreId", "AuthorId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "AuthorGenres",
                keyColumns: new[] { "GenreId", "AuthorId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "BookId", "AuthorId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "BookId", "AuthorId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "BookId", "AuthorId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "BookGenres",
                keyColumns: new[] { "GenreId", "BookId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "BookGenres",
                keyColumns: new[] { "GenreId", "BookId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "BookGenres",
                keyColumns: new[] { "GenreId", "BookId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Added",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Added",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Added",
                table: "BookReviews");

            migrationBuilder.DropColumn(
                name: "DateOfDeath",
                table: "Authors");

            migrationBuilder.RenameColumn(
                name: "Positive",
                table: "ReviewRates",
                newName: "Value");

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "kryminał / akcja");

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3, "dla dzieci" },
                    { 4, "popularnonaukowe" },
                    { 5, "kuchenne" },
                    { 6, "literatura faktu" },
                    { 7, "biografia" },
                    { 8, "historyczne" },
                    { 9, "przygodowe" },
                    { 10, "horror" },
                    { 11, "literatura młodzieżowa" },
                    { 12, "literatura obyczajowa i romans" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "ReviewRates",
                newName: "Positive");

            migrationBuilder.AddColumn<DateTime>(
                name: "Added",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Added",
                table: "Books",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Added",
                table: "BookReviews",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfDeath",
                table: "Authors",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "BirthCity", "BirthCountry", "Confirmed", "DateOfBirth", "DateOfDeath", "Description", "Firstname", "Gender", "Lastname", "PhotoUrl" },
                values: new object[,]
                {
                    { 1, null, null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Andrzej", "mężczyzna", "Sapkowski", "https://iupac.org/cms/wp-content/uploads/2018/05/default-avatar.png" },
                    { 2, null, null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Arthur Conan", "mężczyzna", "Doyle", "https://iupac.org/cms/wp-content/uploads/2018/05/default-avatar.png" },
                    { 3, null, null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "John Ronald Reuel", "mężczyzna", "Tolkien", "https://iupac.org/cms/wp-content/uploads/2018/05/default-avatar.png" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Added", "Confirmed", "Description", "PagesCount", "PhotoUrl", "Released", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 1, 12, 11, 1, 39, 565, DateTimeKind.Utc), false, "Jedyne w Polsce wydanie zawierające wszystkie opowiadania i nowele Arthura Conan Doyle’a o detektywie wszech czasów.", 1108, "https://iupac.org/cms/wp-content/uploads/2018/05/default-avatar.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Księga wszystkich dokonań Sherlocka Holmesa" },
                    { 2, new DateTime(2019, 1, 12, 11, 1, 39, 566, DateTimeKind.Utc), false, "Pierwsza część sagi o wiedźminie Geralcie z Rivii.", 332, "https://iupac.org/cms/wp-content/uploads/2018/05/default-avatar.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ostatnie życzenie" },
                    { 3, new DateTime(2019, 1, 12, 11, 1, 39, 566, DateTimeKind.Utc), false, "Pełne magii i przygód wspaniałe preludium do „Władcy Pierścieni”.", 304, "https://iupac.org/cms/wp-content/uploads/2018/05/default-avatar.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hobbit" }
                });

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "kryminał");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3f38fcb6-fd6e-43c9-d30b-08d6119ae085"),
                column: "Added",
                value: new DateTime(2019, 1, 12, 11, 1, 39, 564, DateTimeKind.Utc));

            migrationBuilder.InsertData(
                table: "AuthorGenres",
                columns: new[] { "GenreId", "AuthorId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "BookAuthors",
                columns: new[] { "BookId", "AuthorId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 1 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "BookGenres",
                columns: new[] { "GenreId", "BookId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 1, 2 },
                    { 1, 3 }
                });
        }
    }
}
