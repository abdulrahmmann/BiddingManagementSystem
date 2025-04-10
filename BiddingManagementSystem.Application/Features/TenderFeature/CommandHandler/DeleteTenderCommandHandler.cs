using BiddingManagementSystem.Application.Features.TenderFeature.Commands;
using BiddingManagementSystem.Application.UOF;
using MediatR;

namespace BiddingManagementSystem.Application.Features.TenderFeature.CommandHandler
{
    public class DeleteTenderCommandHandler : IRequestHandler<DeleteTenderCommand, bool>
    {
        #region INSTANCE FIELDS
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region INJECT INSTANCES INTO CONSTRUCTOR
        public DeleteTenderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

                var existingTender = await _unitOfWork.Tenders.GetTenderByIdAsync(request.Id);

                if (existingTender == null)
                {
                    return false;
                }

                await _unitOfWork.Tenders.DeleteTenderAsync(request.Id);

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
