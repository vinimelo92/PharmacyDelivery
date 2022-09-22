using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using PharmacyDelivery.Data;
using PharmacyDelivery.Models;

namespace PharmacyDelivery.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            var result = await _context.Set<T>().AddAsync(entity);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException);
                throw;
            }
            return result.Entity;
        }

        public async Task<T> DeleteAsync(string id)
        {
            var entity = await this.GetAsync(id);
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            
            var result = _context.Set<T>().Remove(entity);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException);
                throw;
            }
            return result.Entity;
        }

        public async Task<T> GetAsync(string id)
        {
            return await _context.Set<T>().FirstAsync(f => f.Id == id);
        }

        public async Task<List<T>> ListAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            var result = _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException);
                throw;
            }
            return result.Entity;
        }
    }

}