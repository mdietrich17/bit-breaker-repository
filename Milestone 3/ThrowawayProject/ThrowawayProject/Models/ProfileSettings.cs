using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThrowawayProject.Models
{
    public class ProfileSettings
    {
        public string email { get; set; }
        public string username { get; set; }
        public string phonenumber { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string DOB { get; set; }
        public string team { get; set; }
        public string desc { get; set; }

        public ProfileSettings(ApplicationUser info)
        {
            email = info.Email;
            if(info.UserName == null)
            {
                username = "N/A";
            }
            else { username = info.UserName; }

            if(info.PhoneNumber == null)
            {
                phonenumber = "N/A";
            }
            else { phonenumber = info.PhoneNumber; }

            // rest of values are set to null since they are not in db yet
            city = "N/A";
            DOB = "N/A";
            state = "N/A";
            desc = "Empty";
            team = "N/A";



        }


    }
}