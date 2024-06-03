using AutoMapper;
using BankingSystem.API.Requests;
using BankingSystem.API.Response;
using BankingSystem.DataAccess.Entities;
using BankingSystem.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.API.Controllers
{
    [ApiController]
    [Route("transactionType")]
    public class TransactionTypeController : ControllerBase
    {
        private readonly ITransactionTypeServiceInfrastructure _transactionTypeServiceInfrastructure;
        private IMapper _mapper;
        public TransactionTypeController(ITransactionTypeServiceInfrastructure transactionTypeInfrastructure, IMapper mapper)
        {
            _transactionTypeServiceInfrastructure = transactionTypeInfrastructure;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Add([FromBody] TransactionTypeRequest transactionTypeRequest)
        {
            var transactionType = await _transactionTypeServiceInfrastructure.AddAsync(_mapper.Map<TransactionType>(transactionTypeRequest));
            var response = _mapper.Map<TransactionTypeResponse>(transactionType);

            return Ok(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Update(int id, [FromBody] TransactionTypeRequest transactionTypeRequest)
        {
            var transactionType = await _transactionTypeServiceInfrastructure.GetByIdAsync(id);
            _mapper.Map(transactionTypeRequest, transactionType);
            await _transactionTypeServiceInfrastructure.UpdateAsync(transactionType.Id);

            return Ok(_mapper.Map<TransactionTypeResponse>(transactionType));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Delete(int id)
        {
            var transactionType = await _transactionTypeServiceInfrastructure.DeleteAsync(id);

            return Ok(_mapper.Map<TransactionTypeResponse>(transactionType));
        }
    }
}
