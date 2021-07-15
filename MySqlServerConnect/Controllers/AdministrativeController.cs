using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MySqlServerConnect.Data;
using MySqlServerConnect.Models;

namespace MySqlServerConnect.Controllers
{
    [Authorize(Roles ="Admin, User")]
    public class AdministrativeController : Controller
    {

        private readonly UserManager<BlogAppUser> userManager;
        private readonly SignInManager<BlogAppUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        
        public AdministrativeController(RoleManager<IdentityRole> roleManager, UserManager<BlogAppUser> userManager, SignInManager<BlogAppUser> signInManager) 
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
       

        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult CreateRole() 
        
        {
            return View();
        
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)

        {
            if (ModelState.IsValid) 
            
            {
                IdentityRole identityRole = new IdentityRole

                {

                    Name = model.RoleName

                };

                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if (result.Succeeded) 
                {
                    return RedirectToAction("Index", "Home");

                }

                foreach(IdentityError err in result.Errors) 
                
                {

                    ModelState.AddModelError("", err.Description);
                }
                
            
            }
            return View(model);

        }

        [HttpGet]
        public IActionResult ViewUserProfile()

        {
            var userId = userManager.GetUserId(HttpContext.User);
            BlogAppUser user = userManager.FindByIdAsync(userId).Result;
            return View(user);

        }

        [HttpGet]
        public IActionResult EditUserInfo()

        {

            var userId = userManager.GetUserId(HttpContext.User);
            BlogAppUser user = userManager.FindByIdAsync(userId).Result;


            var model = new EditUserViewModel
            {
                FullName = user.GovName,
                LoginName = user.UserName,
                Email = user.Email,
                ConfirmEmail = user.Email,
                DateJoined = user.DateJoined
            };
            
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> EditUserInfo(EditUserViewModel model)

        {

            var userId = userManager.GetUserId(HttpContext.User);
            BlogAppUser user = userManager.FindByIdAsync(userId).Result;

            user.GovName = model.FullName;
            user.UserName = model.LoginName;
            user.Email = model.Email;
            user.Email = model.ConfirmEmail;
            user.DateJoined = model.DateJoined;

            var result = await userManager.UpdateAsync(user);

            if (result.Succeeded) 
            
            {
                return RedirectToAction("ViewUserProfile", "Administrative");
                
            }

            foreach(var er in result.Errors) 
            
            {

                ModelState.AddModelError("", er.Description);
            
            }

            return View(model);
        }

        public async Task<IActionResult> DeleteUser()
        {
            var userId = userManager.GetUserId(HttpContext.User);
            BlogAppUser user = userManager.FindByIdAsync(userId).Result;

            await signInManager.SignOutAsync();
            var result = await userManager.DeleteAsync(user);

            if (result.Succeeded)

            {
                return RedirectToAction("Index", "Home");

            }

            foreach (var er in result.Errors)

            {

                ModelState.AddModelError("", er.Description);

            }

            return View("EditUserInfo");

        }

       

    }
}
