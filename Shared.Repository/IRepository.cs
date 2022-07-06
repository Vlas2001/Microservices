using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shared.Repository
{
    public interface IRepository<T> where T: class
    {
        Task<T> GetAsync(int id);

        Task<List<T>> GetAllAsync();

        Task AddAsync(T item);

        Task DeleteAsync(int id);

        Task EditAsync(T item);
    }
}