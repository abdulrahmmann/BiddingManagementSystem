using AutoMapper;
using BiddingManagementSystem.Application.Common;
using BiddingManagementSystem.Application.Features.BidFeature.DTOs;
using BiddingManagementSystem.Application.Features.BidFeature.Queries;
using BiddingManagementSystem.Application.UOF;
using MediatR;

namespace BiddingManagementSystem.Application.Features.BidFeature.QueryHandler
{
    public class GetBidByIdQueryHandler : IRequestHandler<GetBidByIdQuery, BaseResponse<BidDetailDTO>>
    {
        #region INSTANCE FIELDS
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        #endregion

        #region INJECT INSTANCES INTO CONSTRUCTOR
        public GetBidByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion

        public async Task<BaseResponse<BidDetailDTO>> Handle(GetBidByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                {
                    return BaseResponse<BidDetailDTO>.ErrorResponse("bid request can not be null!");
                }
                var bid = await _unitOfWork.Bids.GetBidByIdAsync(request.Id);

                if (bid == null)
                {
                    return BaseResponse<BidDetailDTO>.NoContentResponse("bid are not found!");
                }

                var bidDto = _mapper.Map<BidDetailDTO>(bid);

                if (bidDto == null)
                {
                    return BaseResponse<BidDetailDTO>.NoContentResponse("bid dto are not found!");
                }

                return BaseResponse<BidDetailDTO>.SuccessResponse(bidDto, "bids are found successfully!");
            }

            catch (Exception ex)
            {
                return BaseResponse<BidDetailDTO>.ErrorResponse(ex.Message);
            }
        }
    }
}
