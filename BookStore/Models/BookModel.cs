﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title cannot be Empty")]
        [StringLength(80,MinimumLength = 7)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Author Field cannot be Empty")]
        public string Author { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        [Required(ErrorMessage = "Please Enter TotalPages")]
        public int TotalPages { get; set; }
        public string Language { get; set; }
    }
}
