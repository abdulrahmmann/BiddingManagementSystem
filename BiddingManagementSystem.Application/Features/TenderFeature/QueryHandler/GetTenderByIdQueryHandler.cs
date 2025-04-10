using AutoMapper;
using BiddingManagementSystem.Application.Common;
using BiddingManagementSystem.Application.Features.TenderFeature.DTOs;
using BiddingManagementSystem.Application.Features.TenderFeature.Queries;
using BiddingManagementSystem.Application.UOF;
using BiddingManagementSystem.Domain.IRepository;
using MediatR;

namespace BiddingManagementSystem.Application.Features.TenderFeature.QueryHandler
{
    public class GetTenderByIdQueryHandler : IRequestHandler<GetTenderByIdQuery, BaseResponse<TenderDTO>>
    {
        #region INSTANCE FIELDS
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITenderRepository _tenderRepository;
        private readonly IMapper _mapper;
        #endregion

        #region INJECT INSTANCES INTO CONSTRUCTOR
        public GetTenderByIdQueryHandler(IUnitOfWork unitOfWork, ITenderRepository tenderRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _tenderRepository = tenderRepository;
            _mapper = mapper;
        }
        #endregion


        public async Task<BaseResponse<TenderDTO>> Handle(GetTenderByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (request is null)
                {
                    return BaseResponse<TenderDTO>.ErrorResponse("Request cannot be null");
                }

                var tender = await _tenderRepository.GetTenderByIdAsync(request.TenderId);

                if (tender == null)
                {
                    return BaseResponse<TenderDTO>.ErrorResponse("Tender not found");
                }

                var tenderDto = _mapper.Map<TenderDTO>(tender);

                return BaseResponse<TenderDTO>.SuccessResponse(tenderDto, "Tender retrieved successfully");
            }
            catch (Exception ex)
            {
                return BaseResponse<TenderDTO>.ErrorResponse(ex.Message);
            }
        }
    }
}
