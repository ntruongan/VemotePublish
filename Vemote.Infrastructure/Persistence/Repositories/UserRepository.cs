using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vemote.Domain.Entities;
using Vemote.Domain.Infrastructure.Persistence.Repositories;

namespace Vemote.Infrastructure.Persistence.Repositories
{
    public class UserRepository : GenericRepository<Users>, IUserRepository
    {
        public UserRepository(VemoteDbContext context) : base(context)
        {
            //dbSetImage = context.Set<Image>();
        }
        public Task<bool> CheckUserExist(string UID)
        {
            var result = _dbSet.Where(x => x.ID.Equals(UID.Trim())).FirstOrDefault();
            if (result != null)
                return Task.FromResult(true);
            return Task.FromResult(false);
        }
    }
}
