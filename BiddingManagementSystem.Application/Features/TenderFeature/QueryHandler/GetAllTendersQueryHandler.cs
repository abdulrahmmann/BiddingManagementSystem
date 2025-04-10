using AutoMapper;
using BiddingManagementSystem.Application.Common;
using BiddingManagementSystem.Application.Features.TenderFeature.DTOs;
using BiddingManagementSystem.Application.Features.TenderFeature.Queries;
using BiddingManagementSystem.Application.UOF;
using MediatR;

namespace BiddingManagementSystem.Application.Features.TenderFeature.QueryHandler
{
    public class GetAllTendersQueryHandler : IRequestHandler<GetAllTendersQuery, BaseResponse<IEnumerable<TenderDTO>>>
    {
        #region INSTANCE FIELDS
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        #endregion

        #region INJECT INSTANCES INTO CONSTRUCTOR
        public GetAllTendersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion


        public async Task<BaseResponse<IEnumerable<TenderDTO>>> Handle(GetAllTendersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var tenders = await _unitOfWork.Tenders.GetAllTendersAsync();

                if (!tenders.Any())
                {
                    return BaseResponse<IEnumerable<TenderDTO>>.NoContentResponse("tenders are not found!");
                }

                var tendersDto = _mapper.Map<IEnumerable<TenderDTO>>(tenders);

                if (tendersDto == null)
                {
                    return BaseResponse<IEnumerable<TenderDTO>>.NoContentResponse("tenders are not found!");
                }

                return BaseResponse<IEnumerable<TenderDTO>>.SuccessResponse(tendersDto, "tenders are found successfully!");
            }
            catch (Exception ex)
            {
                return BaseResponse<IEnumerable<TenderDTO>>.ErrorResponse(ex.Message);
            }
        }
    }
}
