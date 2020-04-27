using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimplySeniors.Models
{
    public class NewsAPI
    {

        public string SourceID { get; set; }
        public string SourceName { get; set; }
        public string Author { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        public string URL { get; set; }
        public string URLImage { get; set; }
        public DateTime PublishTime { get; set; }
    }
}