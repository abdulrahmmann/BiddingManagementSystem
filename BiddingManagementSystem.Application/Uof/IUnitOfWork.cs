using BiddingManagementSystem.Domain.IRepository;

namespace BiddingManagementSystem.Application.UOF
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> GetRepository<T>() where T : class;
        ITenderRepository Tenders { get; }
        IBidRepository Bids { get; }
        void SaveChanges();

        Task SaveChangesAsync();
    }
}
