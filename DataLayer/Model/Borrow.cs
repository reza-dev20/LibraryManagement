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
    /* ketabe amanat dade shode*/
    public class Borrow
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("کد کتاب")]
        [Required]
        public int BookId { get; set; }

        [Required]
        [DisplayName("کد عضویت")]
        public int MemberId { get; set; }

        //Tarikhe amanat gereftan
        [Required]
        [DisplayName("تاریخ گرفتن کتاب")]
        [DataType(DataType.Date, ErrorMessage = "تاریخ")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateLending { get; set; }

        //tarikh ke bayad bargardande shavad
        [Required]
        [DisplayName("تاریخ برگشت کتاب")]
        [DataType(DataType.Date, ErrorMessage = "تاریخ")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]        
        public DateTime DateReturn { get; set; }

        public bool IsReturned{get;set;}

        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }

        [ForeignKey("MemberId")]
        public virtual Member User { get; set; }
    }
}

