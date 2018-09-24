using PracaDyplomowaBackend.Models.ModelsDto.Comment;
using PracaDyplomowaBackend.Models.ModelsDto.Genre;
using PracaDyplomowaBackend.Models.ModelsDto.Library;
using PracaDyplomowaBackend.Models.ModelsDto.Rate;
using System;
using System.Collections.Generic;

namespace PracaDyplomowaBackend.Models.ModelsDto.Book
{
    public class BookDto : DtoBase
    {
        public int Id { get; set; }
        public string Title { get; set; }        
        public string Description { get; set; }
        public int PagesCount { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime Released { get; set; }
        public DateTime Added { get; set; }

        public RateDto Rating { get; set; }

        public IEnumerable<BookAuthorDto> Authors { get; set; }
        public IEnumerable<GenreDto> Genres { get; set; }
        public IEnumerable<CommentDto> Comments { get; set; }
        public IEnumerable<BookReviewDto> Reviews { get; set; }
    }
}
