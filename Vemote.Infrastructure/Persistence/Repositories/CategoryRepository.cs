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
    public class CategoryRepository: GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(VemoteDbContext context) : base(context)
        {
            //dbSetImage = context.Set<Image>();
        }


    }
}
