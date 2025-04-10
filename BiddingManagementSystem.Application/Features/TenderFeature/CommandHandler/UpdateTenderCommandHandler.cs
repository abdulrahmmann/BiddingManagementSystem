using AutoMapper;
using BiddingManagementSystem.Application.Features.TenderFeature.Commands;
using BiddingManagementSystem.Application.UOF;
using BiddingManagementSystem.Domain.Entities;
using MediatR;

namespace BiddingManagementSystem.Application.Features.TenderFeature.CommandHandler
{
    public class UpdateTenderCommandHandler : IRequestHandler<UpdateTenderCommand, bool>
    {
        #region INSTANCE FIELDS
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        #endregion

        #region INJECT INSTANCES INTO CONSTRUCTOR
        public UpdateTenderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion

        public async Task<bool> Handle(UpdateTenderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                {
                    return false;
                }

                var existingTender = await _unitOfWork.Tenders.GetTenderByIdAsync(request.Id);

                if (existingTender == null)
                {
                    return false;
                }

                var updatedTender = _mapper.Map<Tender>(request.TenderDto);

                await _unitOfWork.Tenders.UpdateTenderAsync(request.Id, updatedTender);

                await _unitOfWork.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
