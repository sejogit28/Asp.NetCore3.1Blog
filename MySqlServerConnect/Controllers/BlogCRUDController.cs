using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MySqlServerConnect.Data;
using MySqlServerConnect.Models;

namespace MySqlServerConnect.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BlogCRUDController : Controller
    {
        private readonly UserManager<BlogAppUser> userManager;
        private readonly ApplicationDbContext _datBase;
        

        public BlogCRUDController(ApplicationDbContext dB, UserManager<BlogAppUser> userManager)

        {
            _datBase = dB;
            this.userManager = userManager;
        }

        public IActionResult BlogCreate()
        {

            
            return View();
        }

        public IActionResult ViewAllPosts()

        {
            IEnumerable<Posts> PostList = _datBase.Posts;
            return View(PostList.Reverse());

        }



        [HttpPost]
        public IActionResult BlogCreate(BlogCreateViewModel model) 
        
        {

            var userId = userManager.GetUserId(HttpContext.User);
            BlogAppUser user = userManager.FindByIdAsync(userId).Result;

            if (ModelState.IsValid)
                
            {
                var newBlogPost = new Posts
                {
                    AuthorName = user.GovName,
                    BlogAppUserId = user.Id,
                    Title = model.Title,
                    Summary = model.Summary,
                    DatePosted = DateTime.Now,
                    Text = model.Text,
                    ReadTime = model.ReadTime
                    
                    
                };

                //newBlogPost.Comments = new List<Comments> {  }; //This as not needed to make teh One to Many Posts to comments relationship work
                

                

                _datBase.Posts.Add(newBlogPost);
                _datBase.SaveChanges();
                return RedirectToAction("ViewAllPosts", "BlogCRUD");
                
            
            }           

            return View(model);
        
        }

        [HttpGet]
        public IActionResult BlogUpdate(int Id)
        {



            if(Id == 0) 
            
            {
                return View("ViewAllPosts");
            
            }
            var PostObj = _datBase.Posts.Find(Id);

            if(PostObj == null) 
            
            {
                return View("ViewAllPosts");
            
            }
            


            return View(PostObj);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BlogUpdate(Posts NewPostobj) 
        {
            

            if (NewPostobj == null)

            {
                return View("ViewAllPosts");

            }

            if (ModelState.IsValid) 
            {

                _datBase.Posts.Update(NewPostobj);
                _datBase.SaveChanges();
                return RedirectToAction("ViewAllPosts", "BlogCRUD");
            
            }

            return View(NewPostobj);
        
        
        }



        [HttpGet]
        public IActionResult BlogDelete(int Id)
        {

            if (Id == 0)

            {
                return View("Error");

            }
            var PostObj = _datBase.Posts.Find(Id);

            if (PostObj == null)

            {
                return View("Error");

            }



            return View(PostObj);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BlogDeleted(Posts DeletedObj)
        {
            
            if (DeletedObj == null) 
            {
                return View("Error");
            }
                _datBase.Posts.Remove(DeletedObj);
                _datBase.SaveChanges();
                return RedirectToAction("ViewAllPosts", "BlogCRUD");
           
        }

        

        [HttpGet]
        [AllowAnonymous]
        public IActionResult BlogRead(int Id)
        {


            if (Id == 0)

            {
                return RedirectToAction("ViewAllPosts");

            }
            var PostObj = _datBase.Posts.Find(Id);

            if (PostObj == null)

            {
                return RedirectToAction("ViewAllPosts");

            }

            ViewData["Hope"] = Id;

            IList<Comments> ComList = _datBase.Comments.Include(c => c.Posts)
                .ThenInclude(sc => sc.Comments)
                .ThenInclude(sc => sc.SubComments)
                .Where(c => c.PostsPostId == Id).
                ToList();//This WAS NEEEDED to make the One to many Post to Comments Relationship work. Without this the comment list was null
            
            /*IList<SubComments> SubComList = _datBase.SubComments.Include(p => p.Posts)
                .ThenInclude(c => c.Comments).ThenInclude(sc => sc.SubComments).Where(scc => scc.CommentsCommentId == c.CommentId).ToList();*/

            //ViewBag.Comms = ComList; //This was ALSO not needed to make the one to many post to comments relationship work
            //IList<Comments> SubComList = _datBase.Comments.Include(sc => sc.Su).ThenInclude(sc => sc.Comments).ThenInclude(scc => scc.SubComments).Where(scc => )    



            return View(PostObj);

        }



       /*public RedirectToActionResult BlogReadRedirect()
        { 
            return RedirectToAction("BlogRead", "BlogCRUD", ); 
        }*/

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BlogRead(CommentViewModel vm) 
        
        {         
            
            
            var userId = userManager.GetUserId(HttpContext.User);
            BlogAppUser user = userManager.FindByIdAsync(userId).Result;
           

            if (ModelState.IsValid)
            {
                if (vm.IsSubcomment == false)
                {

                    var newComment = new Comments
                    {
                        
                        Commentor = user.GovName,
                        PostsPostId = vm.PostsPostId,
                        UsersUserId = userId,
                        Subject = vm.Subject,
                        Text = vm.Text,
                        DateCreated = DateTime.Now,
                        IsSubcomment = false
                        

                    };

                    var CurPost = _datBase.Posts.Find(vm.PostsPostId);




                    _datBase.Comments.Add(newComment);
                    _datBase.SaveChanges();
                    return RedirectToAction("BlogRead", "BlogCRUD", new { Id = CurPost.PostId });
                }

                else
                {
                    var newSubComment = new SubComments
                    {

                        Commentor = user.GovName,
                        PostsPostId = vm.PostsPostId,
                        UsersUserId = userId,
                        Subject = vm.Subject,
                        Text = vm.Text,
                        DateCreated = DateTime.Now,
                        CommentsCommentId = vm.CommentsCommentId,
                        IsSubcomment = true
                    };
                    var Post = _datBase.Posts.Find(vm.PostsPostId);




                    _datBase.SubComments.Add(newSubComment);
                    _datBase.SaveChanges();
                    return RedirectToAction("BlogRead", "BlogCRUD", new { Id = Post.PostId });
                }

            }

            
            var Posted = _datBase.Posts.Find(vm.PostsPostId);

            return RedirectToAction("BlogRead", "BlogCRUD", new { Id = Posted.PostId });
        }


    }
}
