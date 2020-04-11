using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class addresses
    {
        public long id { get; set; }
       public string type_of_address { get; set; }
        public string status { get; set; }
        public string entity { get; set; }
        public string number_n_street { get; set; }
        public string suite_or_apt { get; set; }
        public string postal_code { get; set; }
        public string country { get; set; }
        public string notes { get; set; }


    }
}
