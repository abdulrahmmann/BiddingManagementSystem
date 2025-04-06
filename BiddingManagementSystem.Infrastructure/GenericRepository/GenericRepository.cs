using BiddingManagementSystem.Domain.IRepository;
using BiddingManagementSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BiddingManagementSystem.Infrastructure.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        #region INSTANCE FILEDS
        private readonly ApplicationContext _dbContext;
        private readonly DbSet<T> _dbSet;
        #endregion

        #region INJECT INSTANCES INTO CONSTRUCTORS
        public GenericRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        #endregion


        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int Id)
        {
            return _dbSet.Find(Id);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(int Id)
        {
            var entity = _dbSet.Find(Id);
            _dbSet.Remove(entity);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
