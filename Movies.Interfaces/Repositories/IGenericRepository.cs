using System.Linq;

namespace Movies.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T?> GetById(int id);
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        Task<int> SaveChanges();
    }
}
