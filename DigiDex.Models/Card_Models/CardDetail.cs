using DigiDex.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiDex.Models.Card_Models
{
    public class CardDetail
    {
        public int CardId { get; set; }
        public string CardTitle { get; set; }
        public string CardDescription { get; set; }
        
        public string CategoryTitle { get; set; }
        
        public string DeckTitle { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
