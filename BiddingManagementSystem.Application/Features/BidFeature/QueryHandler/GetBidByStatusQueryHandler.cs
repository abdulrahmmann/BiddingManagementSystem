using AutoMapper;
using BiddingManagementSystem.Application.Common;
using BiddingManagementSystem.Application.Features.BidFeature.DTOs;
using BiddingManagementSystem.Application.Features.BidFeature.Queries;
using BiddingManagementSystem.Application.UOF;
using MediatR;

namespace BiddingManagementSystem.Application.Features.BidFeature.QueryHandler
{
    public class GetBidByStatusQueryHandler : IRequestHandler<GetBidByByStatusQuery, BaseResponse<IEnumerable<BidDetailDTO>>>
    {
        #region INSTANCE FIELDS
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        #endregion

        #region INJECT INSTANCES INTO CONSTRUCTOR
        public GetBidByStatusQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion
        public async Task<BaseResponse<IEnumerable<BidDetailDTO>>> Handle(GetBidByByStatusQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                {
                    return BaseResponse<IEnumerable<BidDetailDTO>>.ErrorResponse("request can not be null!");
                }
                var bids = await _unitOfWork.Bids.GetBidByByStatusAsync(request.status);

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
