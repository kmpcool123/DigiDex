using DigiDex.Models.Card_Models;
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
    public class CardController : ApiController
    {

        /// <summary>
        /// Get all existing cards.
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            CardService cardService = CreateCardService();
            var cards = cardService.GetCards();
            return Ok(cards);
        }

        /// <summary>
        /// Create a new card.
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public IHttpActionResult Post(CardCreate card)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCardService();

            if (!service.CreateCard(card))
                return InternalServerError();

            return Ok();
        }

        /// <summary>
        /// Get a single card by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            CardService cardService = CreateCardService();
            var card = cardService.GetCardById(id);
            return Ok(card);
        }

        /// <summary>
        /// get all existing cards of a particular title.
        /// </summary>
        /// <param name="cardTitle"></param>
        /// <returns></returns>
        public IHttpActionResult Get(string cardTitle)
        {
            CardService cardService = CreateCardService();
            var card = cardService.GetCardByTitle(cardTitle);
            return Ok(card);
        }

        /// <summary>
        /// Get all cards of a particular category.
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public IHttpActionResult GetByCategory(string category)
        {
            CardService cardService = CreateCardService();
            var card = cardService.GetCardsByCategoryTitle(category);
            return Ok(card);
        }

        /// <summary>
        /// Get all cards in a particular deck.
        /// </summary>
        /// <param name="deck"></param>
        /// <returns></returns>
        public IHttpActionResult GetCardByDeck(string deck)
        {
            CardService cardService = CreateCardService();
            var card = cardService.GetCardsByDeckTitle(deck);
            return Ok(card);
        }

        private CardService CreateCardService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var cardService = new CardService(userId);
            return cardService;
        }

        /// <summary>
        /// Edit a card.
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public IHttpActionResult Put(CardEdit card)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCardService();

            if (!service.UpdateCard(card))
                return InternalServerError();

            return Ok();
        }

        /// <summary>
        /// Remove a card.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {

            var service = CreateCardService();

            if (!service.DeleteCard(id))
                return InternalServerError();

            return Ok();
        }
    }
}
