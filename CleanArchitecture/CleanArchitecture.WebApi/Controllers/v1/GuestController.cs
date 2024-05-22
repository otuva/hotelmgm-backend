using CleanArchitecture.Core.Features.Guests.Commands.CreateGuest;
using CleanArchitecture.Core.Features.Guests.Commands.DeleteGuestById;
using CleanArchitecture.Core.Features.Guests.Commands.UpdateGuest;
using CleanArchitecture.Core.Features.Guests.Queries.GetAllGuests;
using CleanArchitecture.Core.Features.Guests.Queries.GetGuestById;
using CleanArchitecture.Core.Features.Products.Queries.GetAllProducts;
using CleanArchitecture.Core.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArchitecture.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class GuestController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResponse<IEnumerable<GetAllGuestsViewModel>>))]
        public async Task<PagedResponse<IEnumerable<GetAllGuestsViewModel>>> Get([FromQuery] GetAllGuestsParameter filter)
        {
            return await Mediator.Send(new GetAllGuestsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber });
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetGuestByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateGuestCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdateGuestCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteGuestByIdCommand { Id = id }));
        }
    }
}
