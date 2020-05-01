using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
        
        [ForeignKey("Deck")]
        public int? DeckId { get; set; }
        public virtual Deck Deck { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
