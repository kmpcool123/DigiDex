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
        public IHttpActionResult Get()
        {
            CardService cardService = CreateCardService();
            var cards = cardService.GetCards();
            return Ok(cards);
        }
        public IHttpActionResult Post(CardCreate card)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCardService();

            if (!service.CreateCard(card))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Get(int id)
        {
            CardService cardService = CreateCardService();
            var card = cardService.GetCardById(id);
            return Ok(card);
        }
        private CardService CreateCardService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var cardService = new CardService(userId);
            return cardService;
        }
        public IHttpActionResult Put(CardEdit card)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCardService();

            if (!service.UpdateCard(card))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {

            var service = CreateCardService();

            if (!service.DeleteCard(id))
                return InternalServerError();

            return Ok();
        }
    }
}
