using BiddingManagementSystem.Application.Features.UserFeature.Commands;
using BiddingManagementSystem.Application.Features.UserFeature.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BiddingManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        #region IMediator INSTANCE
        private readonly IMediator _mediator;
        #endregion

        #region INJECT INSTANCES INTO THE CONSTRUCTOR
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        [HttpPost("RegisterNewUser")]
        public async Task<IActionResult> RegisterNewUser(NewUserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _mediator.Send(new RegisterUserCommand(userDTO));

            return Ok(user);
        }

        /*
        [HttpPost("LoginUser")]
        public async Task<IActionResult> LoginUser(LoginUserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _mediator.Send(new LoginUserCommand(userDTO));

            return Ok(user);
        }
        */

    }
}
