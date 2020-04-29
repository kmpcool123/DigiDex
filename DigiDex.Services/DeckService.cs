using DigiDex.Data;
using DigiDex.Models.Deck_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiDex.Services
{
    public class DeckService
    {
        private readonly Guid _userId;
        public DeckService (Guid userId)
        {
            _userId = userId;
        }

        public bool CreateDeck(DeckCreate model)
        {
            var entity =
                new Deck()
                {
                    UserId = _userId,
                    DeckTitle = model.DeckTitle,
                    DeckDescription = model.DeckDescription,
                    CategoryId = model.CategoryId,
                    CreatedUtc = DateTimeOffset.UtcNow
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Decks.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<DeckListItem> GetDecks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Decks.Where(e => e.UserId == _userId)
                    .Select(
                    e =>
                    new DeckListItem
                    {
                        DeckId = e.DeckId,
                        DeckTitle = e.DeckTitle,
                        CreatedUtc = e.CreatedUtc
                    }
                    );
                return query.ToArray();
            }
        }

        public DeckDetail GetDeckById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Decks
                    .Single(e => e.DeckId == id && e.UserId == _userId);
                return
                    new DeckDetail
                    {
                        DeckId = entity.DeckId,
                        Category = entity.Category,
                        DeckTitle = entity.DeckTitle,
                        DeckDescription = entity.DeckDescription,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public DeckDetail GetDeckByTitle(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Decks
                    .Single(e => e.DeckTitle == name && e.UserId == _userId);
                return
                    new DeckDetail
                    {
                        DeckId = entity.DeckId,
                        Category = entity.Category,
                        DeckTitle = entity.DeckTitle,
                        DeckDescription = entity.DeckDescription,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateDeck(DeckEdit Model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Decks
                    .Single(e => e.DeckId == Model.DeckId && e.UserId == _userId);

                entity.DeckTitle = Model.DeckTitle;
                entity.DeckDescription = Model.DeckDescription;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteDeck(int deckId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Decks.Single(e => e.DeckId == deckId && e.UserId == _userId);

                ctx.Decks.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
