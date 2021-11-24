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



namespace Vemote.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private int pageSize = 10;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Task<bool> AddProduct(ProductDTO prodDto)
        {
            throw new NotImplementedException();
        }

/*        private async Task<bool> CheckProduct(Product prod)
        {
*//*            var category = await _unitOfWork.Categories.GetById(prod.CategoryID);
            if (category is null)
                return false;

            var posttype = await _unitOfWork.PostTypes.GetById(prod.PostTypeID);
            if (posttype is null)
                return false;

            var user = await _unitOfWork.Users.GetById(prod.CreatorID);
            if (user is null)
                return false;

            return true;*//*
        }*/

        public bool DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductList> GetAllProduct()
        {
            /*            int pageNumber = (filterParams.Page ?? 1);
                        pageSize = (filterParams.Size ?? pageSize);*/
            int pageNumber = 10;
            int pageSize = 10;
            ProductList prodList = new ProductList();
            var result = await _unitOfWork.Products.GetAllProduct();
            if (result != null && result.Count() > 0)
            {
                var prods = result.Select(prod => _mapper.Map<Product, ProductDTO>(prod));
                /*                prodList.TotalSize = posts.Count();
                                prodList.Products = posts.ToPagedList(pageNumber, pageSize); //them thu vien cho phan trang
                                prodList.PageNumber = pageNumber;*/
                prodList.Products = prods;
                return prodList;
            }

            prodList.TotalSize = 0;
            prodList.PageNumber = 1;
            prodList.Products = new List<ProductDTO>();
            return prodList;
        }
        
        public async Task<ProductDTO> GetProductByID(string id)
        {
            Product prod = await _unitOfWork.Products.GetProdById(id);
            ProductDTO postDto = _mapper.Map<Product, ProductDTO>(prod);
            return postDto;
        }
        private async Task<bool> CanUpdate(Product product)
        {
            bool check = await _unitOfWork.Users.CheckUserExist(product.UpdatedByID);
            if (check)
            {
                check = await _unitOfWork.Users.CheckUserExist(product.CreatedByID);
                if (check)
                {
                    check = await _unitOfWork.Categories.CheckByID(product.CategoryID);
                    if (check)
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        public async Task<bool> UpdateProduct(ProductDTO prodDTO, string uID)
        {
            try
            {
                // Product product = _mapper.Map<ProductDTO, Product>(prod);
                //AddRefProduct
                Product productMap = _mapper.Map<ProductDTO, Product>(prodDTO);
                //productMap.UpdatedByID = uID;
                Product product = await _unitOfWork.Products.UpdateProduct(productMap, uID);
                if (product != null)
                {

                    bool check = await CanUpdate(product);
                    if (check)
                    {
                        //product = await _unitOfWork.Products.UpdateProduct(product);
                        if (product != null)
                        {
                            await _unitOfWork.CompleteAsync();
                            return true;
                        }
                    }
                    return false;
                }
                else
                {
                    return false;
                }

            }
            catch
            {
                return false;
            }
        }
        public async Task<IEnumerable<ProductName>> GetProductNames()
        {
            try
            {
                List<ProductName> productNames = new List<ProductName>();
                //var result = await _unitOfWork.Products.GetAllProduct();
                var result = await _unitOfWork.Products.GetAllProduct();
                if (result != null && result.Count() > 0)
                {
                    var prodNames = result.Select(prod => _mapper.Map<Product, ProductName>(prod));
                    /*                prodList.TotalSize = posts.Count();
                                    prodList.Products = posts.ToPagedList(pageNumber, pageSize); //them thu vien cho phan trang
                                    prodList.PageNumber = pageNumber;*/
                    
                    return prodNames;
                }
                return productNames;
            }
            catch(Exception ex)
            {
                return new List<ProductName>();
            }
        }
        public async Task<ProductList> GetProuctsByCate(string cateID, int Page, int Size)
        {
            try
            {
                ProductList prodList = new ProductList();

                var result = await _unitOfWork.Products.GetProductByCateID(cateID);
                if (result != null && result.Count() > 0)
                {
                    var prods = result.Select(prod => _mapper.Map<Product, ProductDTO>(prod));
                    prodList.TotalSize = prods.Count();
                    prodList.Products = prods.ToPagedList(Page, Size); //them thu vien cho phan trang
                    prodList.PageNumber = Page;

                    return prodList;
                }
                return prodList;
            }
            catch (Exception ex)
            {
                return new ProductList();
            }
        }
    }
}
