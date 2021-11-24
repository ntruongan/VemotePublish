using AutoMapper;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vemote.Application.DTOs;
using Vemote.Application.IServices;
using Vemote.Domain.Entities;
using Vemote.Domain.Infrastructure.Persistence.UoW;
using Vemote.Infrastructure.Persistence.UoW;

namespace Vemote.Application.Services
{
    public class BannerService : IBannerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BannerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BannerDTO>> GetAllBanner()
        {
            int pageNumber = 10;
            int pageSize = 10;
            var result = await _unitOfWork.Banners.GetAllBanner();
            if (result != null && result.Count() > 0)
            {
                var banners = result.Select(bann => _mapper.Map<Banner, BannerDTO>(bann));
                
                return banners;
            }

            return new List<BannerDTO>();
        }

/*        public async Task<IEnumerable<BannerDTO>> GetAll()
        {
            int pageNumber = 10;
            int pageSize = 10;
            var result = await _unitOfWork.Banners.GetAll();
            if (result != null && result.Count() > 0)
            {
                var banners = result.Select(bann => _mapper.Map<Banner, BannerDTO>(bann));

                return banners;
            }

            return new List<BannerDTO>();
        }*/
    }
}
