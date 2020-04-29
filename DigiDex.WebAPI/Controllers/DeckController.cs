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
        public IHttpActionResult Get()
        {
            DeckService deckService = CreateDeckService();
            var decks = deckService.GetDecks();
            return Ok(decks);
        }

        public IHttpActionResult Post(DeckCreate deck)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateDeckService();

            if (!service.CreateDeck(deck))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            DeckService deckService = CreateDeckService();
            var deck = deckService.GetDeckById(id);
            return Ok(deck);
        }

        public IHttpActionResult Get(string name)
        {
            DeckService deckService = CreateDeckService();
            var deck = deckService.GetDeckByTitle(name);

            return Ok(deck);
        }

        public IHttpActionResult Put(DeckEdit deck)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateDeckService();

            if (!service.UpdateDeck(deck))
                return InternalServerError();

            return Ok();
        }

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
