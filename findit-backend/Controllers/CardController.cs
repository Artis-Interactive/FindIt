using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using findit_backend.Models;
using findit_backend.Handlers;
using System.Linq.Expressions;

namespace findit_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly CardHandler _cardHandler;
        private readonly UserIdHandler _userIdHandler;

        public CardController()
        {
            _cardHandler = new CardHandler();
            _userIdHandler = new UserIdHandler();
            
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreateCard(CardModel card, string legalId)
        {
            try
            {
                if (card == null)
                {
                    return BadRequest();
                }
                var cardExits = _cardHandler.CardExists(card.CardNumber);
                if (!cardExits)
                {
                    CardHandler cardHandler = new CardHandler();
                    var result = cardHandler.CreateCard(card);
                    if (!result)
                    { 
                        return BadRequest("Error creating Card: Cards");
                    }
                }
                
                UserIdHandler userIdHandler = new UserIdHandler();
                var userId = userIdHandler.GetUserId(legalId);
                if(userId == Guid.Empty)
                {
                    return BadRequest("Invalid Legal ID");
                }

                var cardId  = _cardHandler.GetCardId(card.CardNumber);
                if (cardId == Guid.Empty)
                {
                    return BadRequest("Error retrieving cardId");
                }

                var userCardCreated = _cardHandler.CreateUserCard(cardId, userId);
                if (!userCardCreated)
                {
                    return BadRequest("Error linking card and user");
                }

                return Ok("Card created and linked to user");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating card");
            }
        }
    }
}
