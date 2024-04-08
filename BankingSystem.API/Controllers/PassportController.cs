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
    [Route("passport")]
    public class PassportController : ControllerBase
    {
        private readonly IPassportServiceInfrastructure _passportServiceInfrastructure;
        private readonly IMapper _mapper;
        public PassportController(IPassportServiceInfrastructure passportServiceInfrastructure, IMapper mapper)
        {
            _passportServiceInfrastructure = passportServiceInfrastructure;
            _mapper = mapper;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Add([FromBody] PassportRequest passportRequest)
        {
            var passport = await _passportServiceInfrastructure.AddAsync(_mapper.Map<Passport>(passportRequest));
            var response = _mapper.Map<PassportResponse>(passport);

            return Ok(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Update(int id, [FromBody] PassportRequest passportRequest)
        {
            var passport = await _passportServiceInfrastructure.GetByIdAsync(id);
            _mapper.Map(passportRequest, passport);
            await _passportServiceInfrastructure.UpdateAsync(passport.Id);

            return Ok(_mapper.Map<PassportResponse>(passport));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _passportServiceInfrastructure.DeleteAsync(id);

            return Ok(_mapper.Map<PassportResponse>(response));
        }
    }
}
