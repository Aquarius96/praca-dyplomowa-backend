﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using PracaDyplomowaBackend.Repo;
using System;

namespace PracaDyplomowaBackend.Repo.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20180805184431_DatabaseStructure")]
    partial class DatabaseStructure
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PracaDyplomowaBackend.Data.DbModels.Comment.AuthorComment", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<Guid>("AuthorId");

                    b.Property<Guid>("UserId");

                    b.Property<DateTime>("Added");

                    b.Property<string>("Content");

                    b.HasKey("Id", "AuthorId", "UserId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("UserId");

                    b.ToTable("AuthorComments");
                });

            modelBuilder.Entity("PracaDyplomowaBackend.Data.DbModels.Comment.BookComment", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<Guid>("BookId");

                    b.Property<Guid>("UserId");

                    b.Property<DateTime>("Added");

                    b.Property<string>("Content");

                    b.HasKey("Id", "BookId", "UserId");

                    b.HasAlternateKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("BookComments");
                });

            modelBuilder.Entity("PracaDyplomowaBackend.Data.DbModels.Common.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BirthCity");

                    b.Property<string>("BirthCountry");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<DateTime>("DateOfDeath");

                    b.Property<string>("Firstname");

                    b.Property<string>("Gender");

                    b.Property<string>("Lastname");

                    b.Property<string>("PhotoUrl");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("PracaDyplomowaBackend.Data.DbModels.Common.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Added");

                    b.Property<string>("Description");

                    b.Property<string>("OriginalTitle");

                    b.Property<int>("PagesCount");

                    b.Property<DateTime>("Released");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("PracaDyplomowaBackend.Data.DbModels.Common.PublishingHouse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Added");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("PhotoUrl");

                    b.HasKey("Id");

                    b.ToTable("PublishingHouses");
                });

            modelBuilder.Entity("PracaDyplomowaBackend.Data.DbModels.Common.Translator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BirthCity");

                    b.Property<string>("BirthCountry");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<DateTime>("DateOfDeath");

                    b.Property<string>("Firstname");

                    b.Property<string>("Gender");

                    b.Property<string>("Lastname");

                    b.HasKey("Id");

                    b.ToTable("Translators");
                });

            modelBuilder.Entity("PracaDyplomowaBackend.Data.DbModels.Common.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Added");

                    b.Property<string>("ConfirmationCode");

                    b.Property<bool>("Confirmed");

                    b.Property<string>("EmailAddress");

                    b.Property<string>("Firstname");

                    b.Property<string>("Lastname");

                    b.Property<string>("Password");

                    b.Property<string>("PasswordSalt");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PracaDyplomowaBackend.Data.DbModels.Edition.BookEdition", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<Guid>("BookId");

                    b.Property<Guid>("PublishingHouseId");

                    b.Property<DateTime>("Added");

                    b.Property<string>("PhotoUrl");

                    b.Property<DateTime>("Released");

                    b.HasKey("Id", "BookId", "PublishingHouseId");

                    b.HasIndex("BookId");

                    b.HasIndex("PublishingHouseId");

                    b.ToTable("BookEditions");
                });

            modelBuilder.Entity("PracaDyplomowaBackend.Data.DbModels.Genre.AuthorGenre", b =>
                {
                    b.Property<Guid>("GenreId");

                    b.Property<Guid>("AuthorId");

                    b.HasKey("GenreId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("AuthorGenres");
                });

            modelBuilder.Entity("PracaDyplomowaBackend.Data.DbModels.Genre.BookGenre", b =>
                {
                    b.Property<Guid>("GenreId");

                    b.Property<Guid>("BookId");

                    b.HasKey("GenreId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("BookGenres");
                });

            modelBuilder.Entity("PracaDyplomowaBackend.Data.DbModels.Genre.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GenreName");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("PracaDyplomowaBackend.Data.DbModels.Library.CurrentlyReadBook", b =>
                {
                    b.Property<Guid>("BookId");

                    b.Property<Guid>("UserId");

                    b.Property<DateTime>("Added");

                    b.HasKey("BookId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("CurrentlyReadBooks");
                });

            modelBuilder.Entity("PracaDyplomowaBackend.Data.DbModels.Library.FavoriteAuthor", b =>
                {
                    b.Property<Guid>("AuthorId");

                    b.Property<Guid>("UserId");

                    b.HasKey("AuthorId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("FavoriteAuthors");
                });

            modelBuilder.Entity("PracaDyplomowaBackend.Data.DbModels.Library.FavoriteBook", b =>
                {
                    b.Property<Guid>("BookId");

                    b.Property<Guid>("UserId");

                    b.HasKey("BookId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("FavoriteBooks");
                });

            modelBuilder.Entity("PracaDyplomowaBackend.Data.DbModels.Library.ReadBook", b =>
                {
                    b.Property<Guid>("BookId");

                    b.Property<Guid>("UserId");

                    b.Property<DateTime>("Added");

                    b.HasKey("BookId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("ReadBooks");
                });

            modelBuilder.Entity("PracaDyplomowaBackend.Data.DbModels.Library.WantedBook", b =>
                {
                    b.Property<Guid>("BookId");

                    b.Property<Guid>("UserId");

                    b.Property<DateTime>("Added");

                    b.HasKey("BookId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("WantedBooks");
                });

            modelBuilder.Entity("PracaDyplomowaBackend.Data.DbModels.Rate.AuthorRate", b =>
                {
                    b.Property<Guid>("AuthorId");

                    b.Property<Guid>("UserId");

                    b.Property<int>("Value");

                    b.HasKey("AuthorId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("AuthorRates");
                });

            modelBuilder.Entity("PracaDyplomowaBackend.Data.DbModels.Rate.BookRate", b =>
                {
                    b.Property<Guid>("BookId");

                    b.Property<Guid>("UserId");

                    b.Property<int>("Value");

                    b.HasKey("BookId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("BookRates");
                });

            modelBuilder.Entity("PracaDyplomowaBackend.Data.DbModels.Rate.ReviewRate", b =>
                {
                    b.Property<Guid>("BookReviewId");

                    b.Property<Guid>("UserId");

                    b.Property<bool>("Positive");

                    b.HasKey("BookReviewId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("ReviewRates");
                });

            modelBuilder.Entity("PracaDyplomowaBackend.Data.DbModels.Relations.BookAuthor", b =>
                {
                    b.Property<Guid>("BookId");

                    b.Property<Guid>("AuthorId");

                    b.HasKey("BookId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("BookAuthors");
                });

            modelBuilder.Entity("PracaDyplomowaBackend.Data.DbModels.Relations.BookEditionTranslator", b =>
                {
                    b.Property<Guid>("BookEditionId");

                    b.Property<Guid>("BookEditionBookId");

                    b.Property<Guid>("BookEditionPublishingHomeId");

                    b.Property<Guid>("TranslatorId");

                    b.HasKey("BookEditionId", "BookEditionBookId", "BookEditionPublishingHomeId", "TranslatorId");

                    b.HasIndex("TranslatorId");

                    b.ToTable("BookEditionTranslator");
                });

            modelBuilder.Entity("PracaDyplomowaBackend.Data.DbModels.Relations.BookReview", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Added");

                    b.Property<Guid>("BookId");

                    b.Property<string>("Content");

                    b.Property<string>("Title");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("BookReviews");
                });

            modelBuilder.Entity("PracaDyplomowaBackend.Data.DbModels.Relations.UserFriend", b =>
                {
                    b.Property<Guid>("Friend1Id");

                    b.Property<Guid>("Friend2Id");

                    b.Property<DateTime>("Added");

                    b.Property<bool>("Confirmed");

                    b.HasKey("Friend1Id", "Friend2Id");

                    b.HasIndex("Friend2Id");

                    b.ToTable("UserFriends");
                });

            modelBuilder.Entity("PracaDyplomowaBackend.Data.DbModels.Role.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RoleName");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("PracaDyplomowaBackend.Data.DbModels.Role.UserRole", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("PracaDyplomowaBackend.Data.DbModels.Comment.AuthorComment", b =>
                {
                    b.HasOne("PracaDyplomowaBackend.Data.DbModels.Common.Author", "Author")
                        .WithMany("AuthorComments")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PracaDyplomowaBackend.Data.DbModels.Common.User", "User")
                        .WithMany("AuthorComments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PracaDyplomowaBackend.Data.DbModels.Comment.BookComment", b =>
                {
                    b.HasOne("PracaDyplomowaBackend.Data.DbModels.Common.Book", "Book")
                        .WithMany("BookComments")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PracaDyplomowaBackend.Data.DbModels.Common.User", "User")
                        .WithMany("BookComments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PracaDyplomowaBackend.Data.DbModels.Edition.BookEdition", b =>
                {
                    b.HasOne("PracaDyplomowaBackend.Data.DbModels.Common.Book", "Book")
                        .WithMany("BookEditions")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PracaDyplomowaBackend.Data.DbModels.Common.PublishingHouse", "PublishingHouse")
                        .WithMany("BookEditions")
                        .HasForeignKey("PublishingHouseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PracaDyplomowaBackend.Data.DbModels.Genre.AuthorGenre", b =>
                {
                    b.HasOne("PracaDyplomowaBackend.Data.DbModels.Common.Author", "Author")
                        .WithMany("AuthorGenres")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PracaDyplomowaBackend.Data.DbModels.Genre.Genre", "Genre")
                        .WithMany("AuthorGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PracaDyplomowaBackend.Data.DbModels.Genre.BookGenre", b =>
                {
                    b.HasOne("PracaDyplomowaBackend.Data.DbModels.Common.Book", "Book")
                        .WithMany("BookGenres")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PracaDyplomowaBackend.Data.DbModels.Genre.Genre", "Genre")
                        .WithMany("BookGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PracaDyplomowaBackend.Data.DbModels.Library.CurrentlyReadBook", b =>
                {
                    b.HasOne("PracaDyplomowaBackend.Data.DbModels.Common.Book", "Book")
                        .WithMany("CurrentlyReadBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PracaDyplomowaBackend.Data.DbModels.Common.User", "User")
                        .WithMany("CurrentlyReadBooks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PracaDyplomowaBackend.Data.DbModels.Library.FavoriteAuthor", b =>
                {
                    b.HasOne("PracaDyplomowaBackend.Data.DbModels.Common.Author", "Author")
                        .WithMany("FavoriteAuthors")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PracaDyplomowaBackend.Data.DbModels.Common.User", "User")
                        .WithMany("FavoriteAuthors")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PracaDyplomowaBackend.Data.DbModels.Library.FavoriteBook", b =>
                {
                    b.HasOne("PracaDyplomowaBackend.Data.DbModels.Common.Book", "Book")
                        .WithMany("FavoriteBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PracaDyplomowaBackend.Data.DbModels.Common.User", "User")
                        .WithMany("FavoriteBooks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PracaDyplomowaBackend.Data.DbModels.Library.ReadBook", b =>
                {
                    b.HasOne("PracaDyplomowaBackend.Data.DbModels.Common.Book", "Book")
                        .WithMany("ReadBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PracaDyplomowaBackend.Data.DbModels.Common.User", "User")
                        .WithMany("ReadBooks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PracaDyplomowaBackend.Data.DbModels.Library.WantedBook", b =>
                {
                    b.HasOne("PracaDyplomowaBackend.Data.DbModels.Common.Book", "Book")
                        .WithMany("WantedBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PracaDyplomowaBackend.Data.DbModels.Common.User", "User")
                        .WithMany("WantedBooks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PracaDyplomowaBackend.Data.DbModels.Rate.AuthorRate", b =>
                {
                    b.HasOne("PracaDyplomowaBackend.Data.DbModels.Common.Author", "Author")
                        .WithMany("AuthorRates")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PracaDyplomowaBackend.Data.DbModels.Common.User", "User")
                        .WithMany("AuthorRates")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PracaDyplomowaBackend.Data.DbModels.Rate.BookRate", b =>
                {
                    b.HasOne("PracaDyplomowaBackend.Data.DbModels.Common.Book", "Book")
                        .WithMany("BookRates")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PracaDyplomowaBackend.Data.DbModels.Common.User", "User")
                        .WithMany("BookRates")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PracaDyplomowaBackend.Data.DbModels.Rate.ReviewRate", b =>
                {
                    b.HasOne("PracaDyplomowaBackend.Data.DbModels.Relations.BookReview", "BookReview")
                        .WithMany("ReviewRates")
                        .HasForeignKey("BookReviewId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PracaDyplomowaBackend.Data.DbModels.Common.User", "User")
                        .WithMany("ReviewRates")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PracaDyplomowaBackend.Data.DbModels.Relations.BookAuthor", b =>
                {
                    b.HasOne("PracaDyplomowaBackend.Data.DbModels.Common.Author", "Author")
                        .WithMany("BookAuthors")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PracaDyplomowaBackend.Data.DbModels.Common.Book", "Book")
                        .WithMany("BookAuthors")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PracaDyplomowaBackend.Data.DbModels.Relations.BookEditionTranslator", b =>
                {
                    b.HasOne("PracaDyplomowaBackend.Data.DbModels.Common.Translator", "Translator")
                        .WithMany("BookEditionTranslators")
                        .HasForeignKey("TranslatorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PracaDyplomowaBackend.Data.DbModels.Edition.BookEdition", "BookEdition")
                        .WithMany("BookEditionTranslators")
                        .HasForeignKey("BookEditionId", "BookEditionBookId", "BookEditionPublishingHomeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PracaDyplomowaBackend.Data.DbModels.Relations.BookReview", b =>
                {
                    b.HasOne("PracaDyplomowaBackend.Data.DbModels.Common.Book", "Book")
                        .WithMany("BookReviews")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PracaDyplomowaBackend.Data.DbModels.Common.User", "User")
                        .WithMany("BookReviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PracaDyplomowaBackend.Data.DbModels.Relations.UserFriend", b =>
                {
                    b.HasOne("PracaDyplomowaBackend.Data.DbModels.Common.User", "Friend1")
                        .WithMany("FriendOf")
                        .HasForeignKey("Friend1Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PracaDyplomowaBackend.Data.DbModels.Common.User", "Friend2")
                        .WithMany("Friends")
                        .HasForeignKey("Friend2Id")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PracaDyplomowaBackend.Data.DbModels.Role.UserRole", b =>
                {
                    b.HasOne("PracaDyplomowaBackend.Data.DbModels.Role.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PracaDyplomowaBackend.Data.DbModels.Common.User", "User")
                        .WithOne("UserRole")
                        .HasForeignKey("PracaDyplomowaBackend.Data.DbModels.Role.UserRole", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
