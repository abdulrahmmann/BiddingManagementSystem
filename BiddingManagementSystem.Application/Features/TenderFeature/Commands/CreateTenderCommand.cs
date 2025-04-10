using BiddingManagementSystem.Application.Common;
using BiddingManagementSystem.Application.Features.TenderFeature.DTOs;
using MediatR;

namespace BiddingManagementSystem.Application.Features.TenderFeature.Commands
{
    public record CreateTenderCommand(CreateTenderDTO TenderDTO) : IRequest<BaseResponse<bool>>;
}
