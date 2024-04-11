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
    [Authorize(Roles ="admin")]
    [Route("cardType")]
    public class CardTypeController : ControllerBase
    {
        private readonly ICardTypeServiceInfrastructure _cardTypeServiceInfrastructure;
        private IMapper _mapper;
        public CardTypeController(ICardTypeServiceInfrastructure cardTypeServiceInfrastructure, IMapper mapper)
        {
            _cardTypeServiceInfrastructure = cardTypeServiceInfrastructure;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Add([FromBody] CardTypeRequest cardTypeRequest)
        {
            var cardType = await _cardTypeServiceInfrastructure.AddAsync(_mapper.Map<CardType>(cardTypeRequest));
            var response = _mapper.Map<CardTypeResponse>(cardType);

            return Ok(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Update(int id, [FromBody] CardTypeRequest cardTypeRequest)
        {
            var cardType = await _cardTypeServiceInfrastructure.GetByIdAsync(id);
            _mapper.Map(cardTypeRequest, cardType);
            await _cardTypeServiceInfrastructure.UpdateAsync(cardType.Id);

            return Ok(_mapper.Map<CardTypeResponse>(cardType));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _cardTypeServiceInfrastructure.DeleteAsync(id);

            return Ok(_mapper.Map<CardTypeResponse>(response));
        }
    }
}
