using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class building_details
    {
        public long id { get; set; }
        public string info_key { get; set; }
        public string value { get; set; }
        public long building_id { get; set; }
    }
}
