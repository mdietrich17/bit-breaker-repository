using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimplySeniors.Models.ViewModel
{
    public class CCViewModel
    {
        public CCViewModel(Post post)
        {
            PostID = post.ID;
            PostTitle = post.Title;
            PostBody = post.Body;
            PostFirstName = post.PostProfile.FIRSTNAME;
            PostLastName = post.PostProfile.LASTNAME;
            PostDate = post.PostDate;

        }
        public string PostTitle { get; set; }
        public string PostBody { get; set; }
        public string PostFirstName { get; set; }
        public string PostLastName { get; set; }

        public DateTime PostDate { get; set; }

        [StringLength(256)]
        public string Text { get; set; }

        public int PostID { get; set; }
    }
}