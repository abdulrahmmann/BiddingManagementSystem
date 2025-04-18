using BiddingManagementSystem.Application.Features.BidFeature.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BiddingManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidController : ControllerBase
    {
        #region IMediator INSTANCE
        private readonly IMediator _mediator;
        #endregion

        #region INJECT INSTANCES INTO THE CONSTRUCTOR
        public BidController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        [HttpGet("GetAllBids")]
        public async Task<IActionResult> GetAllBids()
        {
            if (!ModelState.IsValid)
            {
                return NotFound(ModelState);
            }
            var result = await _mediator.Send(new GetAllBidsQuery());

            return Ok(result);
        }

        [HttpGet("GetBidById:{Id}")]
        public async Task<IActionResult> GetBidById(int Id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound(ModelState);
            }
            var result = await _mediator.Send(new GetBidByIdQuery(Id));

            return Ok(result);
        }

        [HttpGet("GetBidByStatus:{Status}")]
        public async Task<IActionResult> GetBidByStatus(string Status)
        {
            if (!ModelState.IsValid)
            {
                return NotFound(ModelState);
            }
            var result = await _mediator.Send(new GetBidByByStatusQuery(Status));

            return Ok(result);
        }

    }
}
