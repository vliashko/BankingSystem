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
    [Route("banking/client-accounts")] 
    public class ClientAccountController : ControllerBase
    {
        private readonly IClientAccountServiceInfrastructure _clientAccountServiceInfrastructure;
        private readonly IExpenseCalculatorInfrastructure _ExpenseCalculatorInfrastructure;
        private readonly IMapper _mapper;
        public ClientAccountController(IClientAccountServiceInfrastructure clientAccountServiceInfrastructure, IMapper mapper, IExpenseCalculatorInfrastructure ExpenseCalculatorInfrastructure)
        {
            _clientAccountServiceInfrastructure = clientAccountServiceInfrastructure;
            _mapper = mapper;
            _ExpenseCalculatorInfrastructure = ExpenseCalculatorInfrastructure;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Add([FromBody] ClientAccountRequest clientAccountRequest)
        {
            var clientAccount = await _clientAccountServiceInfrastructure.AddAsync(_mapper.Map<ClientAccount>(clientAccountRequest));
            var response = _mapper.Map<ClientAccountResponse>(clientAccount);

            return Ok(response);
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Update(int id, [FromBody] ClientAccountRequest clientAccountRequest)
        {
            var clientAccount = await _clientAccountServiceInfrastructure.GetByIdAsync(id);
            _mapper.Map(clientAccountRequest, clientAccount);
            await _clientAccountServiceInfrastructure.UpdateAsync(clientAccount.Id);

            return Ok(_mapper.Map<ClientAccountResponse>(clientAccount));
        }
    
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _clientAccountServiceInfrastructure.DeleteAsync(id);

            return Ok(_mapper.Map<ClientAccountResponse>(response));
        }

        [HttpGet("client-account")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> GetClientAccountByUserId([FromQuery] int userId)
        {
            var response = await _clientAccountServiceInfrastructure.GetByUserIdAsync(userId);

            return Ok(_mapper.Map<ClientAccountResponse>(response));
        }

     
        [HttpGet("client-expense")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetClientExpenseAsync([FromQuery] int pageSize, [FromQuery] int chunkSize)
        {
            var clientExpenses = await _ExpenseCalculatorInfrastructure.GetClientExpenseAsync(pageSize, chunkSize);

            return Ok(clientExpenses);
        }
    }
}
