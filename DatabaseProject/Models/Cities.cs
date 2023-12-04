using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Models
{
    public class Cities
    {
        public int StateID { get; set; }
        public string StateName { get; set; }

        public string StateAbbrev { get; set; }
         public string Address { get; set; }
       

        public List<all_cities>  all_cities { get; set; }
    }

    public class all_cities
    {
        public int cityId { get; set; }
        public int StateID { get; set; }

       
        public string cityname { get; set; }
    }
}
