namespace BiddingManagementSystem.Infrastructure.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T GetById(int Id);

        void Add(T entity);

        void Delete(int Id);

        void Save();
    }
}
