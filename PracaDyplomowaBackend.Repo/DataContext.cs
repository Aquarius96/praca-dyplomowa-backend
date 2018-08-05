using Microsoft.EntityFrameworkCore;
using PracaDyplomowaBackend.Data.DbModels.Comment;
using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Data.DbModels.Edition;
using PracaDyplomowaBackend.Data.DbModels.Genre;
using PracaDyplomowaBackend.Data.DbModels.Library;
using PracaDyplomowaBackend.Data.DbModels.Rate;
using PracaDyplomowaBackend.Data.DbModels.Relations;
using PracaDyplomowaBackend.Data.DbModels.Role;
using System.Linq;

namespace PracaDyplomowaBackend.Repo
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.Migrate();
        }

        #region DbSets
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<PublishingHouse> PublishingHouses { get; set; }
        public DbSet<Translator> Translators { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<AuthorComment> AuthorComments { get; set; }
        public DbSet<BookComment> BookComments { get; set; }

        public DbSet<BookEdition> BookEditions { get; set; }

        public DbSet<AuthorGenre> AuthorGenres { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }

        public DbSet<CurrentlyReadBook> CurrentlyReadBooks { get; set; }
        public DbSet<ReadBook> ReadBooks { get; set; }
        public DbSet<WantedBook> WantedBooks { get; set; }

        public DbSet<FavoriteAuthor> FavoriteAuthors { get; set; }
        public DbSet<FavoriteBook> FavoriteBooks { get; set; }

        public DbSet<AuthorRate> AuthorRates { get; set; }
        public DbSet<BookRate> BookRates { get; set; }
        public DbSet<ReviewRate> ReviewRates { get; set; }

        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookReview> BookReviews { get; set; }        
        public DbSet<UserFriend> UserFriends { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AuthorComment>().HasKey(sc => new { sc.Id, sc.AuthorId, sc.UserId});
            modelBuilder.Entity<BookComment>().HasKey(sc => new { sc.Id, sc.BookId, sc.UserId });
            modelBuilder.Entity<BookEdition>().HasKey(sc => new { sc.Id, sc.BookId, sc.PublishingHouseId });
            modelBuilder.Entity<AuthorGenre>().HasKey(sc => new { sc.GenreId, sc.AuthorId });
            modelBuilder.Entity<BookGenre>().HasKey(sc => new { sc.GenreId, sc.BookId });
            modelBuilder.Entity<CurrentlyReadBook>().HasKey(sc => new { sc.BookId, sc.UserId });
            modelBuilder.Entity<FavoriteAuthor>().HasKey(sc => new { sc.AuthorId, sc.UserId });
            modelBuilder.Entity<FavoriteBook>().HasKey(sc => new { sc.BookId, sc.UserId });
            modelBuilder.Entity<ReadBook>().HasKey(sc => new { sc.BookId, sc.UserId });
            modelBuilder.Entity<WantedBook>().HasKey(sc => new { sc.BookId, sc.UserId });
            modelBuilder.Entity<AuthorRate>().HasKey(sc => new { sc.AuthorId, sc.UserId });
            modelBuilder.Entity<BookRate>().HasKey(sc => new { sc.BookId, sc.UserId });
            modelBuilder.Entity<ReviewRate>().HasKey(sc => new { sc.BookReviewId, sc.UserId });
            modelBuilder.Entity<BookAuthor>().HasKey(sc => new { sc.BookId, sc.AuthorId });
            modelBuilder.Entity<BookEditionTranslator>().HasKey(sc => new { sc.BookEditionId, sc.BookEditionBookId, sc.BookEditionPublishingHomeId, sc.TranslatorId });                      
            modelBuilder.Entity<UserRole>().HasKey(sc => new { sc.UserId, sc.RoleId });
            modelBuilder.Entity<UserFriend>().HasKey(sc => new { sc.Friend1Id, sc.Friend2Id });            

            modelBuilder.Entity<UserFriend>()
                .HasOne(c => c.Friend1)
                .WithMany(c => c.FriendOf)
                .HasForeignKey(f => f.Friend1Id);                

            modelBuilder.Entity<UserFriend>()
                .HasOne(c => c.Friend2)
                .WithMany(c => c.Friends)
                .HasForeignKey(f => f.Friend2Id)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<ReviewRate>()
                .HasOne(c => c.User)
                .WithMany(c => c.ReviewRates)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }       
    }
}
