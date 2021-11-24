using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vemote.Application.DTOs;


namespace Vemote.Application.IServices
{
    public interface IProductService
    {
        public Task<ProductList> GetAllProduct();
        public Task<ProductDTO> GetProductByID(string id);

        public Task<bool> UpdateProduct(ProductDTO prod, string uID);
        public Task<bool> AddProduct(ProductDTO prod);
        public bool DeleteProduct(int id);
        public Task<IEnumerable<ProductName>> GetProductNames();
        public Task<ProductList> GetProuctsByCate(string cateID, int Page, int Size);
        
    }
}
