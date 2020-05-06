using DigiDex.Models.Deck_Models;
using DigiDex.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DigiDex.WebAPI.Controllers
{
    public class DeckController : ApiController
    {
        /// <summary>
        /// Get all existing decks.
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            DeckService deckService = CreateDeckService();
            var decks = deckService.GetDecks();
            return Ok(decks);
        }

        /// <summary>
        /// Create a new deck.
        /// </summary>
        /// <param name="deck"></param>
        /// <returns></returns>
        public IHttpActionResult Post(DeckCreate deck)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateDeckService();

            if (!service.CreateDeck(deck))
                return InternalServerError();

            return Ok();
        }

        /// <summary>
        /// Get a single deck by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            DeckService deckService = CreateDeckService();
            var deck = deckService.GetDeckById(id);
            return Ok(deck);
        }

        /// <summary>
        /// Get all existing decks by category.
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public IHttpActionResult GetByCategory(string category)
        {
            DeckService deckService = CreateDeckService();
            var deck = deckService.GetDecksByCategoryTitle(category);
            return Ok(deck);
        }

        /// <summary>
        /// Get all existing decks by a particular title.
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public IHttpActionResult Get(string title)
        {
            DeckService deckService = CreateDeckService();
            var deck = deckService.GetDeckByTitle(title);

            return Ok(deck);
        }

        /// <summary>
        /// Edit a deck.
        /// </summary>
        /// <param name="deck"></param>
        /// <returns></returns>
        public IHttpActionResult Put(DeckEdit deck)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateDeckService();

            if (!service.UpdateDeck(deck))
                return InternalServerError();

            return Ok();
        }

        /// <summary>
        /// Remove a deck.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            var service = CreateDeckService();

            if (!service.DeleteDeck(id))
                return InternalServerError();

            return Ok();
        }

        private DeckService CreateDeckService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var deckService = new DeckService(userId);
            return deckService;
        }
    }
}
