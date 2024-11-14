using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVManagerSystem.Data.Models
{
    public class CV
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "الاسم مطلوب")]
        public string Name { get; set; }
        public int PersonalInformationId { get; set; }
        public int ExperienceInformationId { get; set; }
        public PersonalInformation PersonalInformation { get; set; }
        public ExperienceInformation ExperienceInformation { get; set; }
    }
}
