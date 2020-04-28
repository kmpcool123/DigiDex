using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiDex.Models.CardModels
{
    public class CardDetail
    {
        public int CardId { get; set; }
        public string CardTitle { get; set; }
        public string Description { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
