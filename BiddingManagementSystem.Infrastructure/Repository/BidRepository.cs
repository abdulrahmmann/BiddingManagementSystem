using BiddingManagementSystem.Domain.Entities;
using BiddingManagementSystem.Domain.IRepository;
using BiddingManagementSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BiddingManagementSystem.Infrastructure.Repository
{
    public class BidRepository : IGenericRepository<Bid>, IBidRepository
    {
        #region INSTANCE FIELDS
        private readonly ApplicationContext _dbContext;
        #endregion


        #region INJECT INSTANCES INTO CONSTRUCTOR
        public BidRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        public void Add(Bid entity)
        {
            _dbContext.Add(entity);
        }

        public async Task CreateBidAsync(Bid bid)
        {
            await _dbContext.Bids.AddAsync(bid);
        }

        public void Delete(int Id)
        {
            var entity = _dbContext.Bids.Find(Id);
            _dbContext.Remove(entity);
        }

        public IEnumerable<Bid> GetAll()
        {
            return _dbContext.Bids.ToList();
        }

        public async Task<IEnumerable<Bid>> GetAllBidsAsync()
        {
            return await _dbContext.Bids.ToListAsync();
        }

        public async Task<IEnumerable<Bid>> GetBidByByStatusAsync(string status)
        {
            return await _dbContext.Bids.Where(t => t.Status.ToString().Equals(status, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();
        }

        public async Task<Bid> GetBidByIdAsync(int Id)
        {
            return await _dbContext.Bids.SingleOrDefaultAsync(t => t.Id == Id);
        }

        public Bid GetById(int Id)
        {
            return _dbContext.Bids.SingleOrDefault(t => t.Id == Id);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
