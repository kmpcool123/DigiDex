using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiDex.Models
{
    public class CardCreate
    {
        [Required]
        [MinLength(1, ErrorMessage ="Please enter at least 1 character.")]
        [MaxLength(300, ErrorMessage = "There are too many characters in this field. Max length 300 characters.")]

        public int? DeckId { get; set; }
        public string CardTitle { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
    }
}
