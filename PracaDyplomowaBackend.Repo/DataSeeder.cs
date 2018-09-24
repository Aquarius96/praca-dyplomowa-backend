using Microsoft.EntityFrameworkCore;
using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Data.DbModels.Genre;
using PracaDyplomowaBackend.Data.DbModels.Relations;
using PracaDyplomowaBackend.Data.DbModels.Role;
using System;

namespace PracaDyplomowaBackend.Repo
{
    public static class DataSeeder
    {
        public static void EnsureDataForSeeding(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = new Guid("3f38fcb6-fd6e-43c9-d30b-08d6119ae085"),
                    Added = DateTime.UtcNow,
                    ConfirmationCode = Guid.Empty,
                    Confirmed = true,
                    EmailAddress = "aquarius96@wp.pl",
                    Firstname = "Marcin",
                    Lastname = "Zapadka",
                    Password = "AQAAAAEAACcQAAAAELFL9kOX6RSdfEY6XayG8rRXip7ST1br7qyVmlRQ4wlaiFGAQDyzpvUsh9mAH1RdLg==",
                    PhotoUrl = "https://iupac.org/cms/wp-content/uploads/2018/05/default-avatar.png",
                    Username = "Administrator"
                }
            );

            modelBuilder.Entity<Genre>().HasData(
                new Genre
                {
                    Id = 1,
                    Name = "fantasy"
                },
                new Genre
                {
                    Id = 2,
                    Name = "kryminał"
                }
            );

            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = 1,
                    Firstname = "Andrzej",
                    Lastname = "Sapkowski",
                    Gender = "mężczyzna",
                    PhotoUrl = "https://iupac.org/cms/wp-content/uploads/2018/05/default-avatar.png"                    
                },
                new Author
                {
                    Id = 2,
                    Firstname = "Arthur Conan",
                    Lastname = "Doyle",
                    Gender = "mężczyzna",
                    PhotoUrl = "https://iupac.org/cms/wp-content/uploads/2018/05/default-avatar.png"
                },
                new Author
                {
                    Id = 3,
                    Firstname = "John Ronald Reuel",
                    Lastname = "Tolkien",
                    Gender = "mężczyzna",
                    PhotoUrl = "https://iupac.org/cms/wp-content/uploads/2018/05/default-avatar.png"
                }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Added = DateTime.UtcNow,
                    Description = "Jedyne w Polsce wydanie zawierające wszystkie opowiadania i nowele Arthura Conan Doyle’a o detektywie wszech czasów.",
                    Title = "Księga wszystkich dokonań Sherlocka Holmesa",
                    PagesCount = 1108,
                    PhotoUrl = "https://iupac.org/cms/wp-content/uploads/2018/05/default-avatar.png"
                },
                new Book
                {
                    Id = 2,
                    Added = DateTime.UtcNow,
                    Description = "Pierwsza część sagi o wiedźminie Geralcie z Rivii.",
                    Title = "Ostatnie życzenie",
                    PagesCount = 332,
                    PhotoUrl = "https://iupac.org/cms/wp-content/uploads/2018/05/default-avatar.png"
                },
                new Book
                {
                    Id = 3,
                    Added = DateTime.UtcNow,
                    Description = "Pełne magii i przygód wspaniałe preludium do „Władcy Pierścieni”.",
                    Title = "Hobbit",
                    PagesCount = 304,
                    PhotoUrl = "https://iupac.org/cms/wp-content/uploads/2018/05/default-avatar.png"
                }
            );

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "administrator"
                },
                new Role
                {
                    Id = 2,
                    Name = "user"
                }
            );

            modelBuilder.Entity<AuthorGenre>().HasData(
                new AuthorGenre
                {
                    AuthorId = 1,
                    GenreId = 1
                },
                new AuthorGenre
                {
                    AuthorId = 3,
                    GenreId = 1
                },
                new AuthorGenre
                {
                    AuthorId = 2,
                    GenreId = 2
                }
            );

            modelBuilder.Entity<BookGenre>().HasData(
                new BookGenre
                {
                    BookId = 1,
                    GenreId = 2
                },
                new BookGenre
                {
                    BookId = 2,
                    GenreId = 1
                },
                new BookGenre
                {
                    BookId = 3,
                    GenreId = 1
                }
            );

            modelBuilder.Entity<BookAuthor>().HasData(
                new BookAuthor
                {
                    BookId = 1,
                    AuthorId = 2
                },
                new BookAuthor
                {
                    BookId = 2,
                    AuthorId = 1
                },
                new BookAuthor
                {
                    BookId = 3,
                    AuthorId = 3
                }
            );

            modelBuilder.Entity<UserRole>().HasData(
                new UserRole
                {
                    UserId = new Guid("3f38fcb6-fd6e-43c9-d30b-08d6119ae085"),
                    RoleId = 1                    
                }                
            );
        }
    }
}
