using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCRUD.Data
{
    public class EmployeeInfo
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Gender { get; set; }
        
        [Required(ErrorMessage = "생년월일은 생략할 수 없습니다.")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "생년월일")]
       
        public DateTime Birthday { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
