using AutoMapper;
using BiddingManagementSystem.Application.Common;
using BiddingManagementSystem.Application.Features.BidFeature.DTOs;
using BiddingManagementSystem.Application.Features.BidFeature.Queries;
using BiddingManagementSystem.Application.UOF;
using MediatR;

namespace BiddingManagementSystem.Application.Features.BidFeature.QueryHandler
{
    public class GetAllBidsQueryHandler : IRequestHandler<GetAllBidsQuery, BaseResponse<IEnumerable<BidDetailDTO>>>
    {
        #region INSTANCE FIELDS
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        #endregion

        #region INJECT INSTANCES INTO CONSTRUCTOR
        public GetAllBidsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion
        public async Task<BaseResponse<IEnumerable<BidDetailDTO>>> Handle(GetAllBidsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var bids = await _unitOfWork.Bids.GetAllBidsAsync();

                if (!bids.Any())
                {
                    return BaseResponse<IEnumerable<BidDetailDTO>>.NoContentResponse("bids are not found!");
                }

                var bidsDto = _mapper.Map<IEnumerable<BidDetailDTO>>(bids);

                if (bidsDto == null)
                {
                    return BaseResponse<IEnumerable<BidDetailDTO>>.NoContentResponse("bids are not found!");
                }

                return BaseResponse<IEnumerable<BidDetailDTO>>.SuccessResponse(bidsDto, "bids are found successfully!");
            }
            catch (Exception ex)
            {
                return BaseResponse<IEnumerable<BidDetailDTO>>.ErrorResponse(ex.Message);
            }
        }
    }
}
