using AutoMapper;
using BiddingManagementSystem.Application.Features.TenderFeature.Commands;
using BiddingManagementSystem.Application.UOF;
using BiddingManagementSystem.Domain.IRepository;
using MediatR;

namespace BiddingManagementSystem.Application.Features.TenderFeature.CommandHandler
{
    public class DeleteTenderCommandHandler : IRequestHandler<DeleteTenderCommand, bool>
    {
        #region INSTANCE FIELDS
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITenderRepository _tenderRepository;
        private readonly IMapper _mapper;
        #endregion

        #region INJECT INSTANCES INTO CONSTRUCTOR
        public DeleteTenderCommandHandler(IUnitOfWork unitOfWork, ITenderRepository tenderRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _tenderRepository = tenderRepository;
            _mapper = mapper;
        }
        #endregion
        public async Task<bool> Handle(DeleteTenderCommand request, CancellationToken cancellationToken)
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

                await _tenderRepository.DeleteTenderAsync(request.Id);

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
