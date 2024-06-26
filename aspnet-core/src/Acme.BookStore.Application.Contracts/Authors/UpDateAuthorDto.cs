﻿using System.ComponentModel.DataAnnotations;
using System;

namespace Acme.BookStore.Authors
{
    public class UpDateAuthorDto
    {
        [Required]
        [StringLength(AuthorConsts.MaxNameLength)]
        public string Name { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public string? ShortBio { get; set; }
    }
}