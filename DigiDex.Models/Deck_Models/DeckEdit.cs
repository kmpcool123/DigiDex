using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiDex.Models.Deck_Models
{
    public class DeckEdit
    {
        public int DeckId { get; set; }
        public string DeckTitle { get; set; }
        public string DeckDescription { get; set; }
        public string Category { get; set; }
    }
}
