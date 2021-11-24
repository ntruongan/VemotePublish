using AutoMapper;
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
    public class CategoryService: ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CategoryDTO>> GetAllCategory()
        {
            var result = await _unitOfWork.Categories.GetAll();
            if (result != null && result.Count() > 0)
            {
                var bann = result.Select(cate => _mapper.Map<Category, CategoryDTO>(cate));
                return bann;
            }
            return new List<CategoryDTO>();
        }
    }
}
