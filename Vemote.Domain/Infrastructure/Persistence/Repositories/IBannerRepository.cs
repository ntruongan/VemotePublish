using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vemote.Domain.Entities;

namespace Vemote.Domain.Infrastructure.Persistence.Repositories
{
    public interface IBannerRepository
    {
        Task<IEnumerable<Banner>> GetAllBanner();
    }
}
