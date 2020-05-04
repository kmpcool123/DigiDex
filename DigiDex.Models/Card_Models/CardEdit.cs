using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiDex.Models.Card_Models
{
    public class CardEdit
    {
        public int CardId { get; set; }
        public string CardTitle { get; set; }
        public string CardDescription { get; set; }

        public int DeckId { get; set; }
        public string DeckTitle { get; set; }
        public int CategoryTitle { get; set; }
    }
}
