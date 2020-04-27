using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiDex.Data
{
    public class Deck
    {
        [Key]
        public int DeckId { get; set; }

        [Required]
        public string DeckTitle { get; set; }
        public string DeckDescription { get; set; }

        [Required]
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [Required]
        public Guid UserId { get; set; }
    }
}
