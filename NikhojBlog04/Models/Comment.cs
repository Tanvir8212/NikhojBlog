using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NikhojBlog04.Models
{
    public class Comment
    {
        [Key]
        public int id { get; set; }

        public LostPersonPost lostPersonPost { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime dateTime { get; set; }

        public ApplicationUser User { get; set; }

    }
}