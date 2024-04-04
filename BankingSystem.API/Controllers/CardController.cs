using AutoMapper;
using BankingSystem.API.Requests;
using BankingSystem.API.Response;
using BankingSystem.DataAccess.Entities;
using BankingSystem.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.API.Controllers
{
    [ApiController]
    [Authorize(Roles = "admin")]
    [Route("card")]
    public class CardController : ControllerBase
    {
        private readonly ICardServiceInfrastructure _cardServiceInfrastructure;
        private readonly IMapper _mapper;
        public CardController(ICardServiceInfrastructure cardServiceInfrastructure, IMapper mapper)
        {
            _cardServiceInfrastructure = cardServiceInfrastructure;
            _mapper = mapper;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Add([FromBody] CardRequest cardRequest)
        {
            var card = await _cardServiceInfrastructure.AddAsync(_mapper.Map<Card>(cardRequest));
            var response = _mapper.Map<CardResponse>(card);

            return Ok(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Update(int id, [FromBody] CardRequest cardRequest)
        {
            var card = await _cardServiceInfrastructure.GetByIdAsync(id);
            _mapper.Map(cardRequest, card);
            await _cardServiceInfrastructure.UpdateAsync(card.Id);

            return Ok(_mapper.Map<CardResponse>(card));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _cardServiceInfrastructure.DeleteAsync(id);

            return Ok(_mapper.Map<CardResponse>(response));
        }
    }
}
