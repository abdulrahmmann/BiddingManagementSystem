using BiddingManagementSystem.Domain.Entities;
using BiddingManagementSystem.Domain.IRepository;
using BiddingManagementSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BiddingManagementSystem.Infrastructure.Repository
{
    public class TenderRepository : IGenericRepository<Tender>, ITenderRepository
    {
        #region INSTANCE FIELDS
        private readonly ApplicationContext _dbContext;
        #endregion


        #region INJECT INSTANCES INTO CONSTRUCTOR
        public TenderRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion


        #region SPECIFIC METHODS FOR TENDER
        public async Task<IEnumerable<Tender>> GetAllTendersAsync()
        {
            return await _dbContext.Tenders.ToListAsync();
        }

        public async Task<Tender> GetTenderByIdAsync(int Id)
        {
            return await _dbContext.Tenders.SingleOrDefaultAsync(t => t.Id == Id);
        }

        public async Task CreateTenderAsync(Tender Tender)
        {
            var isExist = await _dbContext.Tenders.AnyAsync(t => t.Id == Tender.Id);

            if (isExist)
            {
                throw new Exception("Tender already exists");
            }

            await _dbContext.Tenders.AddAsync(Tender);
        }
        #endregion


        #region GENERIC REPOSITORY METHODS 
        public void Add(Tender entity)
        {
            _dbContext.Add(entity);
        }

        public void Delete(int Id)
        {
            var entity = _dbContext.Tenders.Find(Id);
            _dbContext.Remove(entity);
        }

        public IEnumerable<Tender> GetAll()
        {
            return _dbContext.Tenders.ToList();
        }

        public Tender GetById(int Id)
        {
            return _dbContext.Tenders.SingleOrDefault(t => t.Id == Id)!;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
        #endregion
    }
}
