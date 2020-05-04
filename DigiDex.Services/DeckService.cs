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
                        Category = e.Category.CategoryTitle,
                        CreatedUtc = e.CreatedUtc
                    }
                    );
                return query.ToArray();
            }
        }

        public IEnumerable<DeckListItem> GetDecksByCategoryTitle(string categoryTitle)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Decks.Where(e => e.Category.CategoryTitle == categoryTitle && e.UserId == _userId)
                    .Select(
                    e =>
                    new DeckListItem
                    {
                        DeckId = e.DeckId,
                        DeckTitle = e.DeckTitle,
                        Category = e.Category.CategoryTitle,
                        CreatedUtc = e.CreatedUtc
                    }
                    );
                return query.ToArray();
            }
        }
        
        public IEnumerable<DeckDetail> GetDeckByTitle(string title)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Decks.Where(e => e.DeckTitle == title && e.UserId == _userId)
                    .Select(
                    e =>
                    new DeckDetail
                    {
                        DeckId = e.DeckId,
                        DeckTitle = e.DeckTitle,
                        Category = e.Category.CategoryTitle,
                        DeckDescription = e.DeckDescription,
                        CreatedUtc = e.CreatedUtc,
                        ModifiedUtc = e.ModifiedUtc
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
                        Category = entity.Category.CategoryTitle,
                        DeckTitle = entity.DeckTitle,
                        DeckDescription = entity.DeckDescription,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateDeck(DeckEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Decks
                    .Single(e => e.DeckId == model.DeckId && e.UserId == _userId);

                entity.DeckTitle = model.DeckTitle;
                entity.DeckDescription = model.DeckDescription;
                entity.CategoryId = model.CategoryId;
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
