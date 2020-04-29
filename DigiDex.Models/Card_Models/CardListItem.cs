using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiDex.Models.Card_Models
{
    public class CardListItem
    {
        public int CardId { get; set; }
        public string CardTitle { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
