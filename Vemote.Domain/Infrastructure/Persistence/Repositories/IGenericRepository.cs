using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vemote.Domain.Infrastructure.Persistence.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetByID(string id);
        Task<bool> Add(T entity);
        Task<bool> CheckByID(string id);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
