using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVManagerSystem.Data.Models
{
    public class ExperienceInformation
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "اسم الشركة مطلوب")]
        [MaxLength(20, ErrorMessage = "الحد الاقصى للاسم الشركة 20حرف")]
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string CompanyField { get; set; }
    }
}
