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
    [Route("accountType")]
    public class AccountTypeController : ControllerBase
    {
        private readonly IAccountTypeServiceInfrastructure _accountTypeServiceInfrastructure;
        private readonly IMapper _mapper;
        public AccountTypeController(IAccountTypeServiceInfrastructure accountTypeServiceInfrastructure, IMapper mapper)
        {
            _accountTypeServiceInfrastructure = accountTypeServiceInfrastructure;
            _mapper = mapper;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Add([FromBody] AccountTypeRequest accountTypeRequest)
        {
            var accountType = await _accountTypeServiceInfrastructure.AddAsync(_mapper.Map<AccountType>(accountTypeRequest));
            var response = _mapper.Map<AccountTypeResponse>(accountType);

            return Ok(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Update(int id, [FromBody] AccountTypeRequest accountTypeRequest)
        {
            var accountType = await _accountTypeServiceInfrastructure.GetByIdAsync(id);
            _mapper.Map(accountTypeRequest, accountType);
            await _accountTypeServiceInfrastructure.UpdateAsync(accountType.Id);

            return Ok(_mapper.Map<AccountTypeResponse>(accountType));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _accountTypeServiceInfrastructure.DeleteAsync(id);

            return Ok(_mapper.Map<AccountTypeResponse>(response));
        }
    }
}
