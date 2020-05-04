using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiDex.Models.Deck_Models
{
    public class DeckEdit
    {
        public int DeckId { get; set; }
        [Display(Name ="Title")]
        public string DeckTitle { get; set; }
        [Display(Name ="Description")]
        public string DeckDescription { get; set; }
        public int CategoryId { get; set; }
    }
}
