using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vemote.Domain.Entities;

namespace Vemote.Domain.Infrastructure.Persistence.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProduct();
        Task<Product> GetProdById(string id);
        Task<IEnumerable<Product>> GetProductByCateID(string cateID);
        Task<Product> UpdateProduct(Product prod, string UID);
        Task<Product> AddRefProduct(String prodID);
    }
}
