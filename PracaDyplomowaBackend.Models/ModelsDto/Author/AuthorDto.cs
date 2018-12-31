﻿using PracaDyplomowaBackend.Models.ModelsDto.Comment;
using PracaDyplomowaBackend.Models.ModelsDto.Genre;
using PracaDyplomowaBackend.Models.ModelsDto.Library;
using PracaDyplomowaBackend.Models.ModelsDto.Rate;
using System;
using System.Collections.Generic;

namespace PracaDyplomowaBackend.Models.ModelsDto.Author
{
    public class AuthorDto : DtoBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DateOfBirth { get; set; }        
        public string BirthCity { get; set; }
        public string BirthCountry { get; set; }
        public string Description { get; set; }
        public string Gender { get; set; }
        public string PhotoUrl { get; set; }
        public bool Confirmed { get; set; }

        public RateDto Rating { get; set; }

        public IEnumerable<GenreDto> Genres { get; set; }
        public IEnumerable<CommentDto> Comments { get; set; }
        public IEnumerable<AuthorBookDto> Books { get; set; }
    }
}
