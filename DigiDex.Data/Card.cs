using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiDex.Data
{
    public class Card
    {
        [Key]
        public int CardId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public string CardTitle { get; set; }
        [Required]
        public string CardDescription { get; set; }
        
        public string CardNumber { get; set; }
        

        public int DeckId { get; set; }
        public virtual Deck Deck { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
