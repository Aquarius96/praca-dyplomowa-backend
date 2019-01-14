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
                    EmailAddress = "aquarius96@wp.pl",                    
                    Password = "AQAAAAEAACcQAAAAELo43AUBrHAT76Rmf5YUHxiy51bN30zu1V7mMPGHIcdHV33n1GtuV0Vh7Hnzn0HqfA==",
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
                    Name = "kryminał / akcja"
                },
                new Genre
                {
                    Id = 3,
                    Name = "dla dzieci"
                },
                new Genre
                {
                    Id = 4,
                    Name = "popularnonaukowe"
                },
                new Genre
                {
                    Id = 5,
                    Name = "kuchenne"
                },
                new Genre
                {
                    Id = 6,
                    Name = "literatura faktu"
                },
                new Genre
                {
                    Id = 7,
                    Name = "biografia"
                },
                new Genre
                {
                    Id = 8,
                    Name = "historyczne"
                },
                new Genre
                {
                    Id = 9,
                    Name = "przygodowe"
                },
                new Genre
                {
                    Id = 10,
                    Name = "horror"
                },
                new Genre
                {
                    Id = 11,
                    Name = "literatura młodzieżowa"
                },
                new Genre
                {
                    Id = 12,
                    Name = "literatura obyczajowa i romans"
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
