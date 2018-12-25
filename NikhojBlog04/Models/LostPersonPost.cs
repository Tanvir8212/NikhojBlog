using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NikhojBlog04.Models
{
    public class LostPersonPost
    {
        [key]
        public int id { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        [Display(Name = "Lost Person Name")]
        public string LostPersonName { get; set; }

        [Required]
        [Display(Name = "Lost Person Age")]
        public int LostPersonAge { get; set; }

        [Required]
        [Display(Name = "Contact Person Name")]
        public string ContactName { get; set; }

        [Required]
        [Display(Name = "Contact Address")]
        public string ContactAddress { get; set; }

        [Required]
        [Display(Name = "Contact Phone")]
        public string ContactPhone { get; set; }

        [Required]
        [Display(Name = "Type")]
        public string PostType { get; set; }

        [Required]
        [Display(Name = "Say in details")]
        public string Details { get; set; }

        public List<ApplicationUser> Likes { get; set; }


        public byte[] ImageDatas { get; set; }
        [NotMapped]
        public HttpPostedFileBase UploadImages { get; set; }

        public DateTime dateTime { get; set; }

        public List<Comment> Comments { get; set; }





    }
}