using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SimplySeniors.Models;

namespace SimplySeniors.Models.ViewModel
{
    public class PDViewModel
    {
        public PDViewModel(Profile Profile, string bridges, List<Post> posts)
        {
            ProfileID = Profile.ID;
            ProfileFirstName = Profile.FIRSTNAME;
            ProfileLastName = Profile.LASTNAME;
            ProfileBirthday = Profile.BIRTHDAY;
            ProfileLocation = Profile.LOCATION;
            ProfileVet = Profile.VETSTATUS;
            ProfileOccupation = Profile.OCCUPATION;
            ProfileFamily = Profile.FAMILY;
            ProfileBIO = Profile.BIO;
            ListHobbies = bridges;
            PostList = posts;
        }
        [Display(Name = "Birthday")]
        public int ProfileID { get; set; }

        public string ProfileFirstName { get; set; }

        public string ProfileLastName { get; set; }

        [Display(Name = "Birthday")]
        public DateTime ProfileBirthday { get; set; }

        [Display(Name = "Location")]
        public string ProfileLocation { get; set; }
        [Display(Name = "Veteran?")]
        public bool? ProfileVet { get; set; }

        [Display(Name = "Occupation")]
        public string ProfileOccupation { get; set; }

        [Display(Name = "Family")]
        public string ProfileFamily { get; set; }

        [Display(Name = "Biography")]
        public string ProfileBIO { get; set; }

        [Display(Name = "My Hobbies")]
        public string ListHobbies { get; set; }

        public List<Post> PostList { get; set; }
       

    }
}