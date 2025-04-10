using BiddingManagementSystem.Application.Common;
using BiddingManagementSystem.Application.Features.TenderFeature.Commands;
using BiddingManagementSystem.Application.UOF;
using BiddingManagementSystem.Domain.Entities;
using BiddingManagementSystem.Domain.ValueObjects;
using MediatR;

namespace BiddingManagementSystem.Application.Features.TenderFeature.CommandHandler
{
    public class CreateTenderCommandHandler : IRequestHandler<CreateTenderCommand, BaseResponse<bool>>
    {
        #region INSTANCE FIELDS
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region INJECT INSTANCES INTO CONSTRUCTOR
        public CreateTenderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        public async Task<BaseResponse<bool>> Handle(CreateTenderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // var tender = _mapper.Map<Tender>(request.TenderDTO);
                var dto = request.TenderDTO;

                if (dto is null)
                    return BaseResponse<bool>.ErrorResponse("request can not be null");

                var budgetRange = new Money(dto.BudgetRange_Amount, dto.BudgetRange_Currency);

                var eligibilityCriteria = new EligibilityCriteria(
                    dto.ElgC_ReqBizLicense,
                    dto.ElgC_MinExpYears,
                    dto.ElgC_FinStabReq,
                    dto.ElgC_IndComp
                    );

                var address = new Address(
                    dto.Address_Country,
                    dto.Address_City,
                    dto.Address_Street,
                    dto.Address_ZipCode
                );

                var paymentTerms = new PaymentTerms(
                    dto.PaymentTerms_AdvancePercentage,
                    dto.PaymentTerms_MilestonePercentage,
                    dto.PaymentTerms_FinalApprovalPercentage,
                    dto.PaymentTerms_PaymentMethod,
                    dto.PaymentTerms_PenaltyOfDelays
                );

                var tender = new Tender(
                    referenceNumber: dto.ReferenceNumber,
                    title: dto.Title,
                    description: dto.Description,
                    issuedBy: dto.IssuedBy,
                    deadline: dto.Deadline,
                    issueDate: dto.IssueDate,
                    closingDate: dto.ClosingDate,
                    email: dto.Email,
                    type: dto.Type,
                    industry: dto.Industry,
                    budgetRange: budgetRange,
                    Address: address,
                    Criteria: eligibilityCriteria,
                    PaymentTerms: paymentTerms
                );

                await _unitOfWork.Tenders.CreateTenderAsync(tender);

                await _unitOfWork.SaveChangesAsync();

                return BaseResponse<bool>.CreatedResponse(true, "Tender Successfully Created");
            }
            catch (Exception ex)
            {
                return BaseResponse<bool>.ErrorResponse(ex.Message);
            }
        }
    }
}
