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

namespace Vemote.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerController : ControllerBase
    {
        private IBannerService bannerService;
        public BannerController(IBannerService bann)
        {
            bannerService = bann;
        }

/*        [HttpGet]
        public async Task<IActionResult> GetAllActive()
        {
            var result = await bannerService.GetAllBanner();
            return Ok(result);
        }*/
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await bannerService.GetAllBanner();
                if (result.Count() > 0 && result != null)
                {
                    return StatusCode(200, result);
                }
                else if (result.Count() == 0)
                {
                    return StatusCode(300, "Cannot find any Banner");
                }
                else
                {
                    return StatusCode(400, result);
                }
            }
            catch(Exception ex)
            {
                return StatusCode(666, ex);
            }
        }
    }
}
