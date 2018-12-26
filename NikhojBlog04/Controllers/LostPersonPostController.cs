using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NikhojBlog04.Models;

namespace NikhojBlog04.Controllers
{
    public class LostPersonPostController : Controller
    {
        public ApplicationDbContext dbContext;

        public LostPersonPostController()
        {
            dbContext = new ApplicationDbContext();
        }
        // GET: LostPerson
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DeletePost(int id)
        {
            LostPersonPost lostPersonPost = dbContext.LostPersonPosts.SingleOrDefault(l => l.id == id);
            dbContext.LostPersonPosts.Remove(lostPersonPost);
            dbContext.SaveChanges();


            return RedirectToAction("Index","Home");
        }

    }
}