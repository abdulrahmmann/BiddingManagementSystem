using BiddingManagementSystem.Application.Features.BidFeature.DTOs;
using MediatR;

namespace BiddingManagementSystem.Application.Features.BidFeature.Commands
{
    public record UpdateBidCommand(int BidId, UpdateBidDTO Bid) : IRequest<bool>;

}
