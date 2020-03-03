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
        public UserHomeViewModel(Profile Profile)
        {
            ProfileID = Profile.ID;
            ProfileFirstName = Profile.FIRSTNAME;
            ProfileLastName = Profile.LASTNAME;
        }
        public int ProfileID { get; set; }

        public string ProfileFirstName { get; set; }

        public string ProfileLastName { get; set; }

    }
}