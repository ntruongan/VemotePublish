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
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
       // protected DbSet<Image> dbSetImage;
        public ProductRepository(VemoteDbContext context) : base(context)
        {
            //dbSetImage = context.Set<Image>();
        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {
/*            int minValue = min ?? 0;
            int maxValue = max ?? int.MaxValue;

            if (minValue > maxValue)
                return new List<Post>();*/


            var result = await _dbSet.Where(x => x.Status == true).OrderByDescending(x => x.ID).ToListAsync();
            System.Console.WriteLine(result.Count);
            if (result != null && result.Count() > 0)
                return result;
            return new List<Product>();
        }
        
        public async Task<Product> GetProdById(string id)
        {
            return await _dbSet.Where(x => x.Status == true && x.ID == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByCateID(string cateID)
        {
            return await _dbSet.Where(x => x.CategoryID == cateID && x.Status == true).OrderByDescending(x => x.ID).ToListAsync();
        }

        public async Task<Product> UpdateProduct(Product prod, string UID)
        {
            try
            {
                Product ProductInter = await _dbSet.Where(x => x.ID == prod.ID).FirstOrDefaultAsync();
                if (ProductInter != null)
                {
                    ProductInter.UpdatedAt = DateTime.Now;
                    ProductInter.UpdatedByID = UID;
                    ProductInter.ImageUrl = prod.ImageUrl;
                    ProductInter.Price = prod.Price;
                    ProductInter.Rate = prod.Rate;
                    ProductInter.Inventory = prod.Inventory;
                    ProductInter.CategoryID = prod.CategoryID;
                    ProductInter.Status = prod.Status;
                    ProductInter.Description_Eng = prod.Description_Eng;
                    ProductInter.Description_Vie = prod.Description_Vie;
                    ProductInter.DisplayName_Eng = prod.DisplayName_Eng;
                    ProductInter.DisplayName_Vie = prod.DisplayName_Vie;
                    return ProductInter;
                }
                else
                {
                    return null;
                }
                
            }
            catch (Exception ex)
            {

                return null;
            }
            
        }

        public async Task<Product> AddRefProduct(string prodID)
        {
            try
            {
                Product productNoTrack = await _dbSet.Where(x => x.ID == prodID).FirstOrDefaultAsync();
                if (productNoTrack != null)
                {
                    /*                    product = prod;
                                        _dbSet.Update(product);
                    
                     /*        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [StringLength(28)]
        public string CreatedByID { get; set; }
        public virtual User CreatedBy { get; set; }
        [StringLength(28)]
        public string UpdatedByID { get; set; }
        public virtual User UpdatedBy { get; set; }
        [StringLength(28)]
        public string CategoryID { get; set; }
        public virtual Category Category { get; set; }
                     */
                    //prod.CategoryID = product.CategoryID;
/*                    _dbSet.Attach(prod);
                    prod.CreatedByID = productNoTrack.CreatedByID;
                    prod.CreatedBy = productNoTrack.CreatedBy;
                    prod.Inventory = 13;*/
                    return productNoTrack;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
