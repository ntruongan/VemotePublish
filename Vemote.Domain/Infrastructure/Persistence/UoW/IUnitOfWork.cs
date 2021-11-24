using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vemote.Domain.Entities;
using Vemote.Domain.Infrastructure.Persistence.Repositories;

namespace Vemote.Domain.Infrastructure.Persistence.UoW
{
    public interface IUnitOfWork
    {
        /*        IProductRepository Products { get; }*/
        IProductRepository Products { get; }
        //IGenericRepository<Product> Products { get; }
        /*        IUserRepository Users { get;  }*/
        IUserRepository Users { get; }
        IBannerRepository Banners { get; }
        IGenericRepository<Category> Categories { get; }

        Task CompleteAsync();
    }
}
