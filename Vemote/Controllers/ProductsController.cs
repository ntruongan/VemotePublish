using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Vemote.Application.DTOs;
using Vemote.Application.IServices;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Net.Http.Headers;

namespace Vemote.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _prodService;
        public ProductsController(IProductService prodService)
        {
            _prodService = prodService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _prodService.GetAllProduct();
                if (result.Products.Count()>0 && result != null)
                {
                    return StatusCode(200, result);
                }
                else if(result.Products.Count() == 0)
                {
                    return StatusCode(300, "Cannot find any Products");
                }
                else
                {
                    return StatusCode(400, result);
                }
                
            }
            catch (Exception ex)
            {
                return StatusCode(666, ex);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var result = await _prodService.GetProductByID(id);
                if (result != null)
                {
                    return StatusCode(200, result);
                }
                else
                {
                    return StatusCode(400, String.Format("Cannot find product with id: {0}.", id));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(666, ex);
            }
        }



        [HttpGet("getallname")]
        public async Task<IActionResult> GetAllProductName()
        {
            try
            {
                var result = await _prodService.GetProductNames();
                if (result != null)
                {
                    return StatusCode(200, result);
                }
                else
                {
                    return StatusCode(400, String.Format("Cannot find product name"));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(666, ex);
            }
        }

        

        [HttpGet("GetProductByCate")]
        public async Task<IActionResult> GetProductByCate(string cateID, int pageNum, int size)
        {
            try
            {
                var result = await _prodService.GetProuctsByCate(cateID, pageNum, size);
                if (result != null)
                {
                    return StatusCode(200, result);
                }
                else
                {
                    return StatusCode(400, String.Format("Cannot find product name"));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(666, ex);
            }
        }

        [Authorize]
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateProduct(ProductDTO prdDTO)
        {
            try
            {
                var jwt = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(jwt);
                var uid = token.Subject;
                var result = await _prodService.UpdateProduct(prdDTO, uid);
                if (result != null)
                {
                    return StatusCode(200, result);
                }
                else
                {
                    return StatusCode(400, String.Format("Cannot find product name"));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(666, ex);
            }
        }

    }
}
