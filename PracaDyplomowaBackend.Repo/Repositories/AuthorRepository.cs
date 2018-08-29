using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PracaDyplomowaBackend.Data.DbModels.Comment;
using PracaDyplomowaBackend.Data.DbModels.Common;
using PracaDyplomowaBackend.Data.DbModels.Relations;
using PracaDyplomowaBackend.Models.ModelsDto.Comment;
using PracaDyplomowaBackend.Models.ModelsDto.Library;
using PracaDyplomowaBackend.Repo.Interfaces;
using PracaDyplomowaBackend.Utilities.Providers.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PracaDyplomowaBackend.Repo.Repositories
{
    public class AuthorRepository : RepositoryBase<Author, int>, IAuthorRepository
    {
        public AuthorRepository(DataContext context, IStringProvider stringProvider) : base(context, stringProvider)
        {
        }

        public void AddAuthorComment(AuthorComment authorComment)
        {
            _context.AuthorComments.Add(authorComment);
        }

        public void AddBookAuthor(BookAuthor bookAuthor)
        {
            _context.BookAuthors.Add(bookAuthor);
        }

        public void DeleteAuthorComment(AuthorComment authorComment)
        {
            _context.AuthorComments.Remove(authorComment);
        }

        public AuthorComment GetAuthorComment(int id)
        {
            return _context.AuthorComments.FirstOrDefault(authorComment => authorComment.Id == id);
        }

        public IEnumerable<CommentDto> GetAuthorComments(int authorId)
        {
            var authorComments = _context.Authors.Where(author => author.Id == authorId).SelectMany(author => author.AuthorComments).Include(authorComment => authorComment.User);

            return Mapper.Map<IEnumerable<CommentDto>>(authorComments);
        }

        public IEnumerable<BookAuthorDto> GetBookAuthors(int bookId)
        {
            var bookAuthors = _context.Books.Where(book => book.Id == bookId).SelectMany(book => book.BookAuthors).Select(bookAuthor => bookAuthor.Author);

            return Mapper.Map<IEnumerable<BookAuthorDto>>(bookAuthors);
        }
    }
}
