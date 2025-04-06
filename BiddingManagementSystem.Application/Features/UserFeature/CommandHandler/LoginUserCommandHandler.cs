using AutoMapper;
using BiddingManagementSystem.Application.Common;
using BiddingManagementSystem.Application.Features.UserFeature.Commands;
using BiddingManagementSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BiddingManagementSystem.Application.Features.UserFeature.CommandHandler
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, BaseResponse<bool>>
    {
        #region INSTANCE FIELDS
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        #endregion


        #region INJECT INSTANCES INTO CONSTRUCTOR
        public LoginUserCommandHandler(UserManager<AppUser> userManager, IMapper mapper, IConfiguration configuration)
        {
            _userManager = userManager;
            _mapper = mapper;
            _configuration = configuration;
        }
        #endregion

        public async Task<BaseResponse<bool>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // check if the user is exist.
                var isExist = await _userManager.FindByNameAsync(request.UserDTO.UserName);

                if (isExist is null)
                {
                    return BaseResponse<bool>.ConflictResponse($"The User with UserName: [ {request.UserDTO.UserName} ] is Not Exist!!");
                }

                // map the DTO to the AppUser entity.
                var user = _mapper.Map<AppUser>(request.UserDTO);

                var result = await _userManager.CheckPasswordAsync(user, request.UserDTO.Password);

                // ...
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
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JWT:SecretKey"));

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
                }

                // return BaseResponse<bool>.CreatedResponse(true, "User Logged in successfully");

                // user creation failed.
                return BaseResponse<bool>.UnAuthorizeResponse("UnAuthorize User");

            }
            catch (Exception ex)
            {
                return BaseResponse<bool>.ErrorResponse(ex.Message);
            }
        }
    }
}
