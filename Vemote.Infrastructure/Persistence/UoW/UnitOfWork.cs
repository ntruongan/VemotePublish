using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vemote.Domain.Entities;
using Vemote.Domain.Infrastructure.Persistence.Repositories;
using Vemote.Domain.Infrastructure.Persistence.UoW;
using Vemote.Infrastructure.Persistence.Repositories;

namespace Vemote.Infrastructure.Persistence.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VemoteDbContext _context;
/*        public IGenericRepository<Product> Products { get; private set; }*/
        public IUserRepository Users { get; private set; }
        public IBannerRepository Banners { get; private set; }
        public IProductRepository Products { get; private set; }
        /*        public IUserRepository Users { get; private set; }*/
        /* public ICategoryRepository Categories { get; private set; }*/
        public IGenericRepository<Category> Categories { get; private set; }
        
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.DisposeAsync();
        }
        public UnitOfWork(VemoteDbContext context)
        {
            _context = context;
            _context.ChangeTracker.LazyLoadingEnabled = false;
            //_logger = loggerFactory.CreateLogger("logs");
            Banners = new BannerRepository(_context);
            Products = new ProductRepository(_context);
            Categories = new CategoryRepository(_context);
            Users = new UserRepository(_context);
           // Images = new GenericRepository<Image>(_context);
            //User = new UserRepository(_context, _logger);

        }
    }
}
