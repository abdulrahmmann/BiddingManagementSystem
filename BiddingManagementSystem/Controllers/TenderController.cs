using BiddingManagementSystem.Application.Features.TenderFeature.Commands;
using BiddingManagementSystem.Application.Features.TenderFeature.DTOs;
using BiddingManagementSystem.Application.Features.TenderFeature.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BiddingManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
                return NotFound(ModelState);
            }
            var result = await _mediator.Send(new GetAllTendersQuery());

            return Ok(result);
        }

        [HttpPost("CreateSingleTender")]
        public async Task<IActionResult> CreateSingleTender([FromBody] CreateTenderDTO tenderDTO)
        {
            if (!ModelState.IsValid)
            {
                return NotFound(ModelState);
            }

            var result = await _mediator.Send(new CreateTenderCommand(tenderDTO));

            if (result == null)
            {
                return NotFound("Tender creation failed.");
            }
            return Ok(result);
        }

        [HttpGet("GetTenderById")]
        public async Task<IActionResult> GetTenderById(int TenderId)
        {
            if (!ModelState.IsValid)
            {
                return NotFound(ModelState);
            }

            var result = await _mediator.Send(new GetTenderByIdQuery(TenderId));

            if (result == null)
            {
                return NotFound("failed Get Tender By Id.");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTender(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound(ModelState);
            }
            var result = await _mediator.Send(new DeleteTenderCommand(id));

            return Ok(result);
        }

        [HttpPut("{TenderId}")]
        public async Task<IActionResult> UpdateTender(int TenderId, [FromBody] TenderDTO tenderDTO)
        {
            if (!ModelState.IsValid)
            {
                return NotFound(ModelState);
            }

            var result = await _mediator.Send(new UpdateTenderCommand(TenderId, tenderDTO));

            return Ok(result);
        }
    }
}
