using EXAM.CRUD.Common;
using EXAM.CRUD.Models;

namespace EXAM.CRUD.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetOneAsync(int id);
        //Task<GenericSearch<T>> GetSearch(string search);
    }
}
