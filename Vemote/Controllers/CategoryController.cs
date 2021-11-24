using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vemote.Application.IServices;

namespace Vemote.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService categoryService;
        public CategoryController(ICategoryService category)
        {
            categoryService = category;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await categoryService.GetAllCategory();
                if (result.Count() > 0 && result != null)
                {
                    return StatusCode(200, result);
                }
                else if (result.Count() == 0)
                {
                    return StatusCode(300, "Cannot find any Category");
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
    }
}
