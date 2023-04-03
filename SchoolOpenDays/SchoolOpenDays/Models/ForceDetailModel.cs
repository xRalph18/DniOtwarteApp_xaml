using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolOpenDays.Models
{
    class ForceDetailModel
    {
        public string description { get; set; }
        public string url { get; set; }
        public Engagement_Methods[] engagement_methods { get; set; }
        public string telephone { get; set; }
        public string id { get; set; }
        public string name { get; set; }
    }

    class Engagement_Methods
    {
        public string url { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public string title { get; set; }
    }

}
