using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SimplySeniors.Models;


namespace SimplySeniors.Models.ViewModel
{
    public class UserHomeViewModel
    {
        public UserHomeViewModel(Profile Profile, List<Post> posts)
        {
            ProfileID = Profile.ID;
            ProfileFirstName = Profile.FIRSTNAME;
            ProfileLastName = Profile.LASTNAME;
            PostList = posts;
        }

        public UserHomeViewModel(Profile Profile, List<Post> posts, Double[] Location, List<Profile> followed, List<PostComment> comments)
        {
            ProfileID = Profile.ID;
            ProfileFirstName = Profile.FIRSTNAME;
            ProfileLastName = Profile.LASTNAME;
            PostList = posts;
            Comments = comments;
            Followed = followed;
            latitude = Location.ElementAt(0);
            longitude = Location.ElementAt(1);
        }
        public int ProfileID { get; set; }

        public string ProfileFirstName { get; set; }

        public string ProfileLastName { get; set; }

        public List<Post> PostList { get; set; }

        public List<Profile> Followed { get; set; }

        public Double latitude { get; set; }

        public Double longitude { get; set; }

        public List<PostComment> Comments { get; set; }
    }
}