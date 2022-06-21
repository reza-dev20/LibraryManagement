﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class BookCategory
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        public string CategoryTitle { get; set; }

        public virtual ICollection<Book> BooksInCategory { get; set; }
    }
}
