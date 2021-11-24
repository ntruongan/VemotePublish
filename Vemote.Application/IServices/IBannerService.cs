using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vemote.Application.DTOs;

namespace Vemote.Application.IServices
{
    public interface IBannerService
    {
        public Task<IEnumerable<BannerDTO>> GetAllBanner();
    }
}
