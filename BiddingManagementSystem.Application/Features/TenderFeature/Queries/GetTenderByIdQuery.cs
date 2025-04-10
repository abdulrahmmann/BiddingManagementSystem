using BiddingManagementSystem.Application.Common;
using BiddingManagementSystem.Application.Features.TenderFeature.DTOs;
using MediatR;

namespace BiddingManagementSystem.Application.Features.TenderFeature.Queries
{
    public record GetTenderByIdQuery(int TenderId) : IRequest<BaseResponse<TenderDTO>>;
}
