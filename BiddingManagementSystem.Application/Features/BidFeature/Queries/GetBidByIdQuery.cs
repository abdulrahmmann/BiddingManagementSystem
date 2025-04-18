using BiddingManagementSystem.Application.Common;
using BiddingManagementSystem.Application.Features.BidFeature.DTOs;
using MediatR;

namespace BiddingManagementSystem.Application.Features.BidFeature.Queries
{
    public record GetBidByIdQuery(int Id) : IRequest<BaseResponse<BidDetailDTO>>;
}
