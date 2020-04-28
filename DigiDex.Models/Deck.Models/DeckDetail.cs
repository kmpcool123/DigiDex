using DigiDex.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiDex.Models.Deck.Models
{
    class DeckDetail
    {
        public int DeckId { get; set; }
        public string DeckTitle { get; set; }
        public string DeckDescription { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
