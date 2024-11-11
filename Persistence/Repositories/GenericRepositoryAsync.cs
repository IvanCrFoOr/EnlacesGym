using Application.Interface;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepositoryAsync(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Get entity by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyList<T>> GetAllAsync(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                return await _dbContext.Set<T>().Include(path).ToListAsync();
            }

            return await _dbContext.Set<T>().ToListAsync();
        }


        /// <summary>
        /// Add an entity 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<T> AddAsync(T entity, string email, int userId, string accountType, bool saveAudit = false)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync(email, userId, accountType, saveAudit);
            return entity;
        }

        /// <summary>
        /// Update an entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task UpdateAsync(T entity, string email, int userId, string accountType, bool saveAudit = false)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync(email, userId, accountType, saveAudit);
        }


        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task DeleteAsync(T entity, string email, int userId, string accountType, bool saveAudit = false)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync(email, userId, accountType, saveAudit);
        }

        /// <summary>
        /// Delete All an entities
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task DeleteAllAsync(List<T> entities, string email, int userId, string accountType, bool saveAudit = false)
        {
            _dbContext.Set<T>().RemoveRange(entities);
            await _dbContext.SaveChangesAsync(email, userId, accountType, saveAudit);

        }
    }
}
