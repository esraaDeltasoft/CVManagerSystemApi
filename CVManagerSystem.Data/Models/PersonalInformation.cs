using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVManagerSystem.Data.Models
{
    public class PersonalInformation
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = " الاسم مطلوب")]
        public string FullName { get; set; }
        public string CityName { get; set; }
        [EmailAddress(ErrorMessage = "الايميل غير صحيح")]
        public string Email { get; set; }
        [Required(ErrorMessage = "رقم الموبايل مطلوب")]
        [RegularExpression(@"^\d+$", ErrorMessage = "يجب ان يحتوى رقم الموبايل على ارقام فقط")]
        public string MobileNumber { get; set; }
    }
}
