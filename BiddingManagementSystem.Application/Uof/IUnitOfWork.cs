using BiddingManagementSystem.Domain.IRepository;

namespace BiddingManagementSystem.Application.UOF
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> GetRepository<T>() where T : class;
        void SaveChanges();

        Task SaveChangesAsync();
    }
}
