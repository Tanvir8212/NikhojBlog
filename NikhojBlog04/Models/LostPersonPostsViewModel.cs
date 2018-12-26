using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NikhojBlog04.Models
{
    public class LostPersonPostsViewModel
    {
        public List<LostPersonPost> LostPersonPosts { get; set; }
        public List<Comment> Comments { get; set; }
        public List<ApplicationUser> Users { get; set; }
    }
}