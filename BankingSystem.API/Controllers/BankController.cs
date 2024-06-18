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
    [Route("banking")]
    public class BankController : ControllerBase
    {
        private readonly IBankServiceInfrastructure _bankServiceInfrastructure;
        private readonly IMapper _mapper;
        public BankController(IBankServiceInfrastructure bankServiceInfrastructure, IMapper mapper)
        {
            _bankServiceInfrastructure = bankServiceInfrastructure;
            _mapper = mapper;
        }
      
        [HttpGet("banks")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> GetAll([FromQuery] int pageSize, int pageNumber )
        {
            var response = await _bankServiceInfrastructure.GetAllAsync(pageSize, pageNumber);

            return Ok(response);
        }

        [HttpGet("banks/{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> GetById(int id)
        {
            var bank = await _bankServiceInfrastructure.GetByIdAsync(id);
            var response = _mapper.Map<BankResponse>(bank);

            return Ok(response);
        }

        [HttpPost("banks")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Add([FromBody] BankRequest bankRequest)
        {
            var bank = await _bankServiceInfrastructure.AddAsync(_mapper.Map<Bank>(bankRequest));
            var response = _mapper.Map<BankResponse>(bank);

            return Ok(response);
        }

        [HttpPut("banks/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Update(int id, [FromBody] BankRequest bankRequest)
        {
            var bank = await _bankServiceInfrastructure.GetByIdAsync(id);
            _mapper.Map(bankRequest, bank);
            await _bankServiceInfrastructure.UpdateAsync(bank.Id);

            return Ok(_mapper.Map<BankResponse>(bank));
        }

        [HttpDelete("banks/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _bankServiceInfrastructure.DeleteAsync(id);

            return Ok(_mapper.Map<BankResponse>(response));
        }
    }
}
