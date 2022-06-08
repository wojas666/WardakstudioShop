using System.Linq.Expressions;

namespace Wardakstudio.Services.ProductsAPI.Repository.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(int id);

        Task<IReadOnlyList<T>> GetAll();

        Task<T> Add(T entity);

        Task Update(T entity);

        Task Delete(T entity);

        Task DeleteById(int id);

        Task<bool> Exists(int id);

    }
}
