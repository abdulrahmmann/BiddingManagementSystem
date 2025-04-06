using AutoMapper;
using BiddingManagementSystem.Application.Common;
using BiddingManagementSystem.Application.Features.UserFeature.Commands;
using BiddingManagementSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BiddingManagementSystem.Application.Features.UserFeature.CommandHandler
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, BaseResponse<bool>>
    {
        #region INSTANCE FIELDS
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        #endregion


        #region CONSTRUCTOR
        public RegisterUserCommandHandler(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        #endregion

        public async Task<BaseResponse<bool>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // check if the user is exist.
                var isExist = await _userManager.FindByEmailAsync(request.UserDTO.Email);

                if (isExist is not null)
                {
                    return BaseResponse<bool>.ConflictResponse($"The User with Email: [ {request.UserDTO.Email} ] is Already Exist!!");
                }

                // map the DTO to the AppUser entity.
                var user = _mapper.Map<AppUser>(request.UserDTO);

                var result = await _userManager.CreateAsync(user, request.UserDTO.Password);

                // user creation failed.
                if (!result.Succeeded)
                {
                    var errorMessages = string.Join(", ", result.Errors.Select(e => e.Description));

                    return BaseResponse<bool>.ErrorResponse($"User creation failed: {errorMessages}");
                }

                // user creation successfully.
                return BaseResponse<bool>.CreatedResponse(true, "User created successfully");
            }
            catch (Exception ex)
            {
                return BaseResponse<bool>.ErrorResponse(ex.Message);
            }
        }
    }
}
