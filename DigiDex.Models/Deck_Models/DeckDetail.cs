
using DigiDex.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiDex.Models.Deck_Models
{
    public class DeckDetail
    {
        public int DeckId { get; set; }
        public string DeckTitle { get; set; }
        public string DeckDescription { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
