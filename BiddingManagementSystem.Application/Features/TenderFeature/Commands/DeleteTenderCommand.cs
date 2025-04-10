using MediatR;

namespace BiddingManagementSystem.Application.Features.TenderFeature.Commands
{
    public record DeleteTenderCommand(int Id) : IRequest<bool>;
}
