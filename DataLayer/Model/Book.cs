using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public int BookId { get; set; }
        [MaxLength(14)]
        [DisplayName("زبان کتاب")]
        public string BookLanguage { get; set; }
        [MaxLength(100)]
        [DisplayName("عنوان کتاب")]
        public string BookTitle { get; set; }
        [DisplayName("دسته بندی")]
        public int BookCategoryId { get; set; }
        [MaxLength(100)]
        [DisplayName("نویسنده")]
        public string BookAuthor { get; set; }  
        [MaxLength(150)]
        [DisplayName("ناشر")]
        public string BookPublisher { get; set; }
        [DisplayName("تعداد صفحات")]
        public int BookPageCount { get; set; }
        [DisplayName("تعداد موجود")]
        public int AvailableCount { get; set; }
        [DisplayName("سال انتشار")]
        public int PublicationYear { get; set; }
                
        //Shomare serial ketab
        public int ISBN { get; set; }

        [ForeignKey("BookCategoryId")]
        public virtual BookCategory BookCategory { get; set; }
        public virtual ICollection<Borrow> Borrow { get; set; }
    }
}
