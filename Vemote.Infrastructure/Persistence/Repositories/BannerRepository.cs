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
    public class BannerRepository : GenericRepository<Banner>, IBannerRepository
    {
        public BannerRepository(VemoteDbContext context) : base(context)
        {
            //dbSetImage = context.Set<Image>();
        }

        public async Task<IEnumerable<Banner>> GetAllBanner()
        {
            var result = await _dbSet.Where(x => x.Status == true).OrderByDescending(x => x.ID).ToListAsync();
            System.Console.WriteLine(result.Count);
            if (result != null && result.Count() > 0)
                return result;
            return new List<Banner>();
        }
    }
}
