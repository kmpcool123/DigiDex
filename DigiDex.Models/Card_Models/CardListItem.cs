using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiDex.Models.Card_Models
{
    public class CardListItem
    {
        public int CardId { get; set; }
        public string CardTitle { get; set; }
        public int DeckId { get; set; } 
        public string DeckTitle { get; set; }
        public int CategoryId { get; set; }

        public string CategoryTitle { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
