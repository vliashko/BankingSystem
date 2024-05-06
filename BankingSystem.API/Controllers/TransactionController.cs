using AutoMapper;
using BankingSystem.API.Requests;
using BankingSystem.API.Response;
using BankingSystem.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.API.Controllers
{
    [ApiController]
    [Route("transaction")]
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

        [HttpPost("make-transaction")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Add([FromBody] TransactionRequest transactionRequest)
        {
            var response = await _stripeServiceInfrastructure.MakeTransactionAsync(transactionRequest.Token,transactionRequest.SenderNumberAccount, transactionRequest.ConsumerNumberAccount, transactionRequest.Amount, transactionRequest.TransactionTypeId, transactionRequest.Currency);

            return Ok(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Update(int id, [FromBody] TransactionRequest transactionRequest)
        {
            var transaction = await _transactionServiceInfrastructure.GetByIdAsync(id);
            _mapper.Map(transactionRequest, transaction);
            await _transactionServiceInfrastructure.UpdateAsync(transaction.Id);

            return Ok(_mapper.Map<TransactionResponse>(transaction));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Delete(int id)
        {
            var transaction = await _transactionServiceInfrastructure.DeleteAsync(id);

            return Ok(_mapper.Map<TransactionResponse>(transaction));
        }
    }
}

