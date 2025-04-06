using BiddingManagementSystem.Application.Features.TenderFeature.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BiddingManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderController : ControllerBase
    {
        #region IMediator INSTANCE
        private readonly IMediator _mediator;
        #endregion

        #region INJECT INSTANCES INTO THE CONSTRUCTOR
        public TenderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        [HttpGet("GetAllTendars")]
        public async Task<IActionResult> GetAllTendars()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _mediator.Send(new GetAllTendersQuery());

            return Ok(result);
        }
    }
}
