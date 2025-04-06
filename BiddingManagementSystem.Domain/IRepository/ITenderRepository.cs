using BiddingManagementSystem.Domain.Entities;

namespace BiddingManagementSystem.Domain.IRepository
{
    public interface ITenderRepository : IGenericRepository<Tender>
    {
        public Task<IEnumerable<Tender>> GetAllTendersAsync();

        public Task<Tender> GetTenderByIdAsync(int Id);

    }
}
