using BiddingManagementSystem.Domain.Entities;

namespace BiddingManagementSystem.Domain.IRepository
{
    public interface IBidRepository : IGenericRepository<Bid>
    {
        public Task<IEnumerable<Bid>> GetAllBidsAsync();

        public Task<Bid> GetBidByIdAsync(int Id);
        public Task<IEnumerable<Bid>> GetBidByByStatusAsync(string status);
    }
}
