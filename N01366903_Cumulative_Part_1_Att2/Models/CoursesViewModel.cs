using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace N01366903_Cumulative_Part_1_Att2.Models
{
    public class CoursesViewModel
    {
        public int classid { get; set; }
        public string classcode { get; set; }
        public int teacherid { get; set; }
        public DateTime startdate { get; set; }
        public DateTime finishdate { get; set; }
        public string classname { get; set; }
    }
}