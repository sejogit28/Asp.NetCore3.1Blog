using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MySqlServerConnect.Data;
using MySqlServerConnect.Models;

namespace MySqlServerConnect.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AuthorController : Controller
    {

        private readonly UserManager<BlogAppUser> userManager;
        private readonly SignInManager<BlogAppUser> signInManager;
        private readonly ApplicationDbContext _datBase;




        public AuthorController(UserManager<BlogAppUser> userManager, SignInManager<BlogAppUser> signInManager, ApplicationDbContext dB)

        {
            _datBase = dB;
            this.userManager = userManager;
            this.signInManager = signInManager;

        }

      
        public IActionResult AuthorView()
        {
            //IEnumerable<Authors> authList = _datBase.Authors;
            //return View(authList);
            return View();
        }


        [HttpGet]
        public IActionResult AuthorCreate()
        {

            return View();
        }

        


    }
}
