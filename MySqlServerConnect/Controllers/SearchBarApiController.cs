using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlServerConnect.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MySqlServerConnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SearchBarApiController : Controller
    {
        private readonly ApplicationDbContext _datBase;
        public SearchBarApiController(ApplicationDbContext _dB) 
        {
            _datBase = _dB;


        }

        [Produces("application/json")]
        [HttpGet("search")]
        public async Task<IActionResult> search()
        {
            try
            {
                string term = HttpContext.Request.Query["term"].ToString();
                var searchTitle = _datBase.Posts.Where(p => p.Title.Contains(term))
                                                .Select(p => p.Title).ToList();
                return Ok(searchTitle);
            }
            catch
            {
                return BadRequest();
            }
        }


    }
}
