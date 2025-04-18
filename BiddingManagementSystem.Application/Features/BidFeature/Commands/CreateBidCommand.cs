using BiddingManagementSystem.Application.Features.BidFeature.DTOs;
using MediatR;

namespace BiddingManagementSystem.Application.Features.BidFeature.Commands
{
    public record CreateBidCommand(CreateBidDTO BidDTO) : IRequest<int>;
}
