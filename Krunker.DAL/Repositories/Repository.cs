using Krunker.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Krunker.DAL.Repositories
{
    /// <summary>
    /// Simple extendable generic repository.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity the repository should handle.</typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IHasID, new()
    {
        /// <summary>
        /// The context of the the DB.
        /// </summary>
        protected readonly ShopContext shopContext;

        /// <summary>
        /// Create new reposirty.
        /// </summary>
        /// <param name="shopContext">Shop context object.</param>
        public Repository(ShopContext shopContext)
        {
            this.shopContext = shopContext;
        }


        public virtual IQueryable<TEntity> GetAll()
        {
            try
            {
                return shopContext.Set<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task<TEntity> GetItemByIdAsync(Guid id)
        {
            try
            {
                TEntity entity = await GetAll().FirstOrDefaultAsync(e => e.Id == id);
                if (entity is null) throw new KeyNotFoundException("The requested ID was not found.");
                return entity;
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(id)} could not be fetched: {ex.Message}");
            }
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }
            try
            {
                EntityEntry<TEntity> entry = await shopContext.AddAsync(entity);
                await shopContext.SaveChangesAsync();
                return entry.Entity;
            }
            catch (DbUpdateException dbEx)
            {
                throw new DbUpdateException($"Issue while saving to DB: {dbEx.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }
            try
            {
                shopContext.Update(entity);
                await shopContext.SaveChangesAsync();
                return entity;
            }

            catch (DbUpdateException dbEx)
            {
                throw new DbUpdateException($"Issue while saving to DB: {dbEx.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }

        public virtual async Task<TEntity> RemoveAsync(TEntity entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }
            try
            {
                if (entity is IArchivable)
                {
                    (entity as IArchivable).Archived = true;
                    return await UpdateAsync(entity);
                } else
                {
                    shopContext.Remove(entity);
                    return entity;
                }
            }

            catch (DbUpdateException dbEx)
            {
                throw new DbUpdateException($"Issue while archiving in DB: {dbEx.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be archived: {ex.Message}");
            }
        }
    }
}
