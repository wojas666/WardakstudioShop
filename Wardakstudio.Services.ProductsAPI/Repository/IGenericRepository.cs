using System.Linq.Expressions;

namespace Wardakstudio.Services.ProductsAPI.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(int id);

        Task<IReadOnlyList<T>> GetAll();

        Task<T> Add(T entity);

        Task<T> Update(T entity);

        Task<bool> Delete(T entity);

        Task<bool> DeleteById(int id);

        Task<bool> Exists(int id);

    }
}
