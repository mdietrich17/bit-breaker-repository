using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimplySeniors.Models.ViewModel;
using SimplySeniors.DAL;

namespace SimplySeniors.Models.ViewModel
{
    public class FollowerInheritanceModel
    {
        private HobbiesContext db = new HobbiesContext();
        public FollowerInheritanceModel(List<Profile> profile)
        {
            results = new List<FollowerSearch>();
           List<FollowerSearch> unsorted = new List<FollowerSearch>();
            foreach(Profile info in profile)
            {
                results.Add(new FollowerSearch() { FirstName = info.FIRSTNAME, LastName = info.LASTNAME, State = info.STATE, id = info.ID, Hobby = db.HobbyBridges.Where(x => x.ProfileID == info.ID).Select(x => x.Hobby.NAME).FirstOrDefault() });
            }
            


        }
        public List<FollowerSearch> results { get; set; }
    }


}