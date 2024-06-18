using AutoMapper;
using BankingSystem.API.Requests;
using BankingSystem.API.Response;
using BankingSystem.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.API.Controllers
{
    [ApiController]
    [Route("banking/transactions")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionServiceInfrastructure _transactionServiceInfrastructure;
        private readonly IStripeServiceInfrastructure _stripeServiceInfrastructure;
        private IMapper _mapper;
        public TransactionController(ITransactionServiceInfrastructure transactionServiceInfrastructure, IMapper mapper, IStripeServiceInfrastructure stripeServiceInfrastructure)
        {
            _transactionServiceInfrastructure = transactionServiceInfrastructure;
            _stripeServiceInfrastructure = stripeServiceInfrastructure;
            _mapper = mapper;
        }

        [HttpPost("transaction")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Add([FromBody] TransactionRequest transactionRequest)
        {
            var response = await _stripeServiceInfrastructure.MakeTransactionAsync(transactionRequest.Token, transactionRequest.SenderNumberAccount, transactionRequest.ConsumerNumberAccount, transactionRequest.Amount, transactionRequest.TransactionTypeId, transactionRequest.Currency, transactionRequest.ClientAccountId);

            return Ok(response);
        }

        [HttpGet("transaction/{clientAccountId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> GetClientTransaction(int clientAccountId, [FromQuery] int chunkSize)
        {
            var response = await _transactionServiceInfrastructure.GetTransactionsByAccount(clientAccountId, chunkSize);

            return Ok(response);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> GetAllTransaction(int pageSize, int chunkSize)
        {
            var response = await _transactionServiceInfrastructure.GetAllTransactionsAsync(pageSize, chunkSize);

            return Ok(response);
        }

        [HttpPut("{transactionId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Update(int transactionId, [FromBody] TransactionRequest transactionRequest)
        {
            var transaction = await _transactionServiceInfrastructure.GetByIdAsync(transactionId);
            _mapper.Map(transactionRequest, transaction);
            await _transactionServiceInfrastructure.UpdateAsync(transaction.Id);

            return Ok(_mapper.Map<TransactionResponse>(transaction));
        }

        [HttpDelete("{transactionId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Delete(int transactionId)
        {
            var transaction = await _transactionServiceInfrastructure.DeleteAsync(transactionId);

            return Ok(_mapper.Map<TransactionResponse>(transaction));
        }
    }
}
