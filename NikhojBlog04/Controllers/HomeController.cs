using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NikhojBlog04.Models;
using System.Data.Entity;

namespace NikhojBlog04.Controllers
{
    public class HomeController : Controller
    {

        public ApplicationDbContext dbContext;
        protected UserManager<ApplicationUser> UserManager { get; set; }

        public HomeController()
        {
            dbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.dbContext));
        }

        public ActionResult Index()
        {
            LostPersonPostsViewModel lostPersonPostsViewModel = new LostPersonPostsViewModel();
            lostPersonPostsViewModel.LostPersonPosts = dbContext.LostPersonPosts.Include(l => l.User).Include(c => c.Comments).ToList();
            lostPersonPostsViewModel.Comments = dbContext.Comments.ToList();

            if (User.IsInRole(Role.Admin))
            {
                return View("IndexForAdmin", lostPersonPostsViewModel);
            }
            return View("Index", lostPersonPostsViewModel);          
        }

        public ActionResult About()
        {
            ViewBag.Message = "This is a website to find and search lost people...";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Tanvir Mahmud Khan";

            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Post()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreatePost(LostPersonPost lostPersonPost)
        {
            lostPersonPost.User = UserManager.FindById(User.Identity.GetUserId());

            //lostPersonPost.User = (ApplicationUser)System.Web.HttpContext.Current.User;

            lostPersonPost.dateTime = DateTime.Now;

            //lostPersonPost.ImageDatas = new byte[lostPersonPost.UploadImages.ContentLength];
            //lostPersonPost.UploadImages.InputStream.Read(lostPersonPost.ImageDatas, 0, lostPersonPost.ImageDatas.Length);

            dbContext.LostPersonPosts.Add(lostPersonPost);
            dbContext.SaveChanges();
            return RedirectToAction("Index","Home");
        }

        public ActionResult Comment(int lostPersonPostID)
        {
            Comment c = new Comment();
            c.lostPersonPost = new LostPersonPost();
           
            return View("Comment", c);
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreateComment(Comment c)
        {

            c.User = UserManager.FindById(User.Identity.GetUserId());
            c.dateTime = DateTime.Now;
            
            dbContext.Comments.Add(c);
            dbContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

    }
}