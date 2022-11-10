using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal SOSUContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(SOSUContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<TEntity> GetById(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task Insert(TEntity entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task Delete(object id)
        {
            TEntity entityToDelete = await dbSet.FindAsync(id);
            await Delete(entityToDelete);
        }

        public async Task Delete(TEntity entityToDelete)
        {
            await Task.Run(() =>
            {
                dbSet.Remove(entityToDelete);
            });
        }

        public async Task Update(TEntity entityToUpdate)
        {
            await Task.Run(() =>
            {
                dbSet.Update(entityToUpdate);
            });
        }
    }
}