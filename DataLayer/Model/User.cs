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
    public class User
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(70)]
        [DisplayName("نام")]
        public string Name { get; set; }
        
        [MaxLength(70)]
        [DisplayName("نام خانوادگی")]       
        public string Family { get; set; }

        [DisplayName("شماره تماس")]        
        [MaxLength(11)]
        public string MobileNumber { get; set; }

        [DisplayName("نام کاربری")]
        [Required(ErrorMessage = "!لطفا نام کاربری خود را وارد نمایید")]
        [MaxLength(70)]
        public string UserName { get; set; }

        [DisplayName("رمز عبور")]
        [Required(ErrorMessage = "!لطفا رمز عبور خود را وارد نمایید")]
        [MaxLength(100)]
        public string HashPassword { get; set; }
    
        [DisplayName("تاریخ")]
        [DataType(DataType.Date, ErrorMessage = "تاریخ")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RegistrationDate { get; set; }
        public int RoleId {
            get { return 1; } set { } }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    

        public string FullName {
            get { return Name + " " + Family; }
        }
    }
}
