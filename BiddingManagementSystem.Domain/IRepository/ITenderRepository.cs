using BiddingManagementSystem.Domain.Entities;

namespace BiddingManagementSystem.Domain.IRepository
{
    public interface ITenderRepository : IGenericRepository<Tender>
    {
        public Task<IEnumerable<Tender>> GetAllTendersAsync();

        public Task<Tender> GetTenderByIdAsync(int Id);

        public Task CreateTenderAsync(Tender Tender);
        public Task UpdateTenderAsync(int Id, Tender Tender);
        public Task DeleteTenderAsync(int Id);
    }
}
