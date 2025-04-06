using BiddingManagementSystem.Application.Common;
using BiddingManagementSystem.Application.Features.UserFeature.DTOs;
using MediatR;

namespace BiddingManagementSystem.Application.Features.UserFeature.Commands
{
    public record RegisterUserCommand(NewUserDTO UserDTO) : IRequest<BaseResponse<bool>>;
}
