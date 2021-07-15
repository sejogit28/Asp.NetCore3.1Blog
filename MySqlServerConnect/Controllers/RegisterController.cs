using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using MySqlServerConnect.Data;
using MySqlServerConnect.Models;
using Microsoft.AspNetCore.Authorization;

namespace MySqlServerConnect.Controllers
{    [AllowAnonymous]
    public class RegisterController : Controller
    {
        

        private readonly UserManager<BlogAppUser> userManager;
        private readonly SignInManager<BlogAppUser> signInManager;
        

        public RegisterController(UserManager<BlogAppUser> userManager, SignInManager<BlogAppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
           
        }


        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                var results = await signInManager.PasswordSignInAsync(model.LoginName, model.Password, model.RememberMe, false);
                

                if (results.Succeeded)
                {
                    
                    return RedirectToAction("BlogMainPage", "MainBlog");

                }

               
                    
                 ModelState.AddModelError(string.Empty, "Invalid Login Attempted");

                

            }

            return View(model); //When you just put view, it assumes you mean the view that you are typing in at tha momemt(it assumes "AuthorCreate in this instance")
        }                       //Something goes wrong when awaiting the return view on the line above. The page crashes. This seems to happen for any page, not just this one. Must look into..
                                //..await features to find out why

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");

        }



        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newUser = new BlogAppUser { UserName = model.LoginName, GovName = model.FullName, Email = model.Email, DateJoined = model.DateJoined };
                var results = await userManager.CreateAsync(newUser, model.Password);
             
          


                if (results.Succeeded)
                {

                    await userManager.AddToRoleAsync(newUser, "User");
                    if (model.FullName == "Sean Joseph") 
                    {
                        await userManager.AddToRoleAsync(newUser, "Admin");
                        await userManager.AddToRoleAsync(newUser, "Author");
                    
                    }
                    await signInManager.SignInAsync(newUser, isPersistent: false);
                    return RedirectToAction("BlogMainPage", "MainBlog");

                }

                foreach (var err in results.Errors)
                {

                    ModelState.AddModelError("", err.Description);

                }

            }

            return View(model); //When you just put view, it assumes you mean the view that you are typing in at tha momemt(it assumes "AuthorCreate in this instance")
        }                       //Something goes wrong when awaiting the return view on the line above. The page crashes. This seems to happen for any page, not just this one. Must look into..
                                //..await features to find out why


        
    }
}
