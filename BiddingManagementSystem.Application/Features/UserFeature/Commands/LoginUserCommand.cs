using BiddingManagementSystem.Application.Common;
using BiddingManagementSystem.Application.Features.UserFeature.DTOs;
using MediatR;

namespace BiddingManagementSystem.Application.Features.UserFeature.Commands
{
    public record LoginUserCommand(LoginUserDTO UserDTO) : IRequest<LoginResponse>;
}
