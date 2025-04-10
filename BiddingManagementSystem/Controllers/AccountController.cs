using AutoMapper;
using BiddingManagementSystem.Application.Features.UserFeature.Commands;
using BiddingManagementSystem.Application.Features.UserFeature.DTOs;
using BiddingManagementSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BiddingManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        #region IMediator INSTANCE
        private readonly IMediator _mediator;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        #endregion

        #region INJECT INSTANCES INTO THE CONSTRUCTOR
        public AccountController(IMediator mediator, UserManager<AppUser> userManager, IMapper mapper, IConfiguration configuration)
        {
            _mediator = mediator;
            _userManager = userManager;
            _mapper = mapper;
            _configuration = configuration;
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

        [HttpPost("LoginUser")]
        public async Task<IActionResult> LoginUser(LoginUserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // check if the user is exist.
                var isExist = await _userManager.FindByNameAsync(userDTO.UserName);

                if (isExist is null)
                {
                    return BadRequest($"The User with UserName: [ {userDTO.UserName} ] is Not Exist!!");
                }

                // map the DTO to the AppUser entity.
                var user = _mapper.Map<AppUser>(userDTO);

                var result = await _userManager.CheckPasswordAsync(user, userDTO.Password);

                if (result)
                {
                    // Create claims
                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                    claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

                    // Add roles to claims
                    var roles = await _userManager.GetRolesAsync(user);
                    foreach (var role in roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
                    }

                    // Generate token
                    var secretKey = _configuration["JWT:SecretKey"];

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!));

                    var sc = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


                    var token = new JwtSecurityToken
                        (
                        claims: claims,
                        issuer: _configuration["JWT:Issuer"],
                        audience: _configuration["JWT:Audience"],
                        expires: DateTime.Now.AddHours(1),
                        signingCredentials: sc
                        );

                    var _token = new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo,
                    };

                    return Ok(_token);
                }
                return BadRequest("Server Error");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
