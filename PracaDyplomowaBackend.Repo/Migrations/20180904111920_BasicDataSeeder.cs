using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PracaDyplomowaBackend.Repo.Migrations
{
    public partial class BasicDataSeeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "BirthCity", "BirthCountry", "DateOfBirth", "DateOfDeath", "Firstname", "Gender", "Lastname", "PhotoUrl" },
                values: new object[,]
                {
                    { 1, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrzej", "mężczyzna", "Sapkowski", "https://iupac.org/cms/wp-content/uploads/2018/05/default-avatar.png" },
                    { 2, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arthur Conan", "mężczyzna", "Doyle", "https://iupac.org/cms/wp-content/uploads/2018/05/default-avatar.png" },
                    { 3, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Ronald Reuel", "mężczyzna", "Tolkien", "https://iupac.org/cms/wp-content/uploads/2018/05/default-avatar.png" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Added", "Description", "OriginalTitle", "PagesCount", "PhotoUrl", "Released", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 9, 4, 11, 19, 20, 378, DateTimeKind.Utc), "Jedyne w Polsce wydanie zawierające wszystkie opowiadania i nowele Arthura Conan Doyle’a o detektywie wszech czasów.", "brak", 1108, "https://iupac.org/cms/wp-content/uploads/2018/05/default-avatar.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Księga wszystkich dokonań Sherlocka Holmesa" },
                    { 2, new DateTime(2018, 9, 4, 11, 19, 20, 378, DateTimeKind.Utc), "Pierwsza część sagi o wiedźminie Geralcie z Rivii.", "brak", 332, "https://iupac.org/cms/wp-content/uploads/2018/05/default-avatar.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ostatnie życzenie" },
                    { 3, new DateTime(2018, 9, 4, 11, 19, 20, 378, DateTimeKind.Utc), "Pełne magii i przygód wspaniałe preludium do „Władcy Pierścieni”.", "brak", 304, "https://iupac.org/cms/wp-content/uploads/2018/05/default-avatar.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hobbit" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "GenreName" },
                values: new object[,]
                {
                    { 1, "fantasy" },
                    { 2, "kryminał" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { 1, "administrator" },
                    { 2, "user" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Added", "ConfirmationCode", "Confirmed", "EmailAddress", "Firstname", "Lastname", "Password", "PhotoUrl", "Username" },
                values: new object[] { new Guid("3f38fcb6-fd6e-43c9-d30b-08d6119ae085"), new DateTime(2018, 9, 4, 11, 19, 20, 376, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), true, "aquarius96@wp.pl", "Marcin", "Zapadka", "AQAAAAEAACcQAAAAELFL9kOX6RSdfEY6XayG8rRXip7ST1br7qyVmlRQ4wlaiFGAQDyzpvUsh9mAH1RdLg==", "https://iupac.org/cms/wp-content/uploads/2018/05/default-avatar.png", "Administrator" });

            migrationBuilder.InsertData(
                table: "AuthorGenres",
                columns: new[] { "GenreId", "AuthorId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 2, 2 }
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
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("3f38fcb6-fd6e-43c9-d30b-08d6119ae085"), 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("3f38fcb6-fd6e-43c9-d30b-08d6119ae085"), 1 });

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

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3f38fcb6-fd6e-43c9-d30b-08d6119ae085"));
        }
    }
}
