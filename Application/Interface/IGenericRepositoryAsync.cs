//using Application.Utils;
using System.Linq.Expressions;

namespace Application.Interface
{
    public interface IGenericRepositoryAsync<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync(string path);
        Task<T> AddAsync(T entity, string email, int userId, string accountType, bool saveAudit = false);
        Task UpdateAsync(T entity, string email, int userId, string accountType, bool saveAudit = false);
        Task DeleteAsync(T entity, string email, int userId, string accountType, bool saveAudit = false);
        Task DeleteAllAsync(List<T> entities, string email, int userId, string accountType, bool saveAudit = false);
    }
}
