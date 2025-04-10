using BiddingManagementSystem.Domain.IRepository;
using BiddingManagementSystem.Infrastructure.GenericRepository;
using BiddingManagementSystem.Infrastructure.Persistence;

namespace BiddingManagementSystem.Application.UOF
{
    public class UnitOfWork : IUnitOfWork
    {
        #region INSTANCE FILEDS
        private readonly ApplicationContext _dbContext;
        private Dictionary<Type, object> _repositories;
        #endregion

        #region INJECT INSTANCES INTO CONSTRUCTORS
        public UnitOfWork(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
            _repositories = new Dictionary<Type, object>();

        }
        #endregion

        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            if (_repositories.ContainsKey(typeof(T)))
            {
                return (IGenericRepository<T>)_repositories[typeof(T)];
            }

            var repository = new GenericRepository<T>(_dbContext);
            _repositories.Add(typeof(T), repository);
            return repository;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
