using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiDex.Models.Category.Models
{
    public class CategoryCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "Please enter at least one character.")]
        [MaxLength(100, ErrorMessage = "Maximum Category Title length is 100 characters.")]
        [Display(Name ="Category Title")]
        public string CategoryTitle { get; set; }
    }
}
