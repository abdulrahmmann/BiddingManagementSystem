using AutoMapper;
using BiddingManagementSystem.Application.Features.TenderFeature.Commands;
using BiddingManagementSystem.Application.UOF;
using BiddingManagementSystem.Domain.Entities;
using BiddingManagementSystem.Domain.IRepository;
using MediatR;

namespace BiddingManagementSystem.Application.Features.TenderFeature.CommandHandler
{
    public class UpdateTenderCommandHandler : IRequestHandler<UpdateTenderCommand, bool>
    {
        #region INSTANCE FIELDS
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITenderRepository _tenderRepository;
        private readonly IMapper _mapper;
        #endregion

        #region INJECT INSTANCES INTO CONSTRUCTOR
        public UpdateTenderCommandHandler(IUnitOfWork unitOfWork, ITenderRepository tenderRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _tenderRepository = tenderRepository;
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

                var existingTender = await _tenderRepository.GetTenderByIdAsync(request.Id);

                if (existingTender == null)
                {
                    return false;
                }

                var updatedTender = _mapper.Map<Tender>(request.TenderDto);

                await _tenderRepository.UpdateTenderAsync(request.Id, updatedTender);

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
