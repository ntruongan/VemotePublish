using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vemote.Domain.Infrastructure.Persistence.Repositories;

namespace Vemote.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected VemoteDbContext _context;
        protected DbSet<T> _dbSet;
        public GenericRepository(VemoteDbContext context)
        {
            _context = context;
            //_logger = logger;
            _dbSet = _context.Set<T>();

        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByID(string id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<bool> Add(T entity)
        {
            try
            {
                var result = await _dbSet.AddAsync(entity);
                if (result != null)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> CheckByID(string id)
        {
            try
            {
                var result = await _dbSet.FindAsync(id);
                if (result != null)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> AddRange(IEnumerable<T> entities)
        {
            try
            {
                await _dbSet.AddRangeAsync(entities);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(T entity)
        {
            try
            {   
                var result = _dbSet.Update(entity);
                if (result != null)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(T entity)
        {
            try
            {
                _dbSet.Remove(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }


}
