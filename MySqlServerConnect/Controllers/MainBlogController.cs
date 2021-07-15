using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlServerConnect.Data;
using MySqlServerConnect.Models;

namespace MySqlServerConnect.Controllers
{
    [AllowAnonymous]
    public class MainBlogController : Controller
    {
        private readonly ApplicationDbContext _datBase;

        public MainBlogController(ApplicationDbContext dB) 
        
        {
            _datBase = dB;
       
        }

        [HttpGet]
        public IActionResult Search()
        {
            IEnumerable<Posts> PostList = _datBase.Posts;
            return View(PostList.Reverse());
        }

        [HttpGet]
        public IActionResult BlogMainPage() 
        {
            IEnumerable<Posts> PostList = _datBase.Posts;
            return View(PostList.Reverse());
        }

        [HttpGet]
        public IActionResult CreateNewPost()
        {
            return View();
        }

        
        public async Task<IActionResult> Search (string searchTitle) 
        { 
            if(searchTitle != null)
            {
                var searchData = _datBase.Posts.Where(p => p.Title.Contains(searchTitle)).ToList();
                return View(searchData);
            }
            else
            {
                return View(await _datBase.Posts.ToListAsync());
            }
        }   
    }
}
