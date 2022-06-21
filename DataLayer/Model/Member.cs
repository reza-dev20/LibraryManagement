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
    public class Member
    {
        [Key]
        public int MemberId { get; set; }

        //public int MemberCode { get; set; }

        [Required]
        [MaxLength(70)]
        [DisplayName("نام")]
        public string Name { get; set; }

        [Required]
        [MaxLength(70)]
        [DisplayName("نام خانوادگی")]
        public string Family { get; set; }

        [Required]
        [MaxLength(10)]
        [DisplayName("کد ملی")]
        public string NationalCode { get; set; }

        [Required]
        [MaxLength(11)]
        [DisplayName("شماره موبایل")]
        public string MobileNumber { get; set; }

        /*        [MaxLength(100)]
                public string HashPassword { get; set; }*/

        [Required]
        [DisplayName("تاریخ")]
        [DataType(DataType.Date, ErrorMessage = "تاریخ")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RegistrationDate { get; set; }

        public int RoleId
        {
            get { return 3; }
            set { }
        }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

        public virtual ICollection<Borrow> Borrow { get; set; }
        public string FullName
        {
            get { return Name + " " + Family; }            
        }
    }
}
