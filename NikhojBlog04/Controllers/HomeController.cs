﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NikhojBlog04.Models;

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
            lostPersonPostsViewModel.LostPersonPosts = dbContext.LostPersonPosts.ToList();
            lostPersonPostsViewModel.Comments = dbContext.Comments.ToList();
            return View(lostPersonPostsViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

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

            lostPersonPost.dateTime = DateTime.Now;

            //lostPersonPost.ImageDatas = new byte[lostPersonPost.UploadImages.ContentLength];
            //lostPersonPost.UploadImages.InputStream.Read(lostPersonPost.ImageDatas, 0, lostPersonPost.ImageDatas.Length);

            dbContext.LostPersonPosts.Add(lostPersonPost);
            dbContext.SaveChanges();
            return RedirectToAction("Index","Home");
        }

    }
}