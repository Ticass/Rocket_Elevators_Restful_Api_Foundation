using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class columns
    {
        public long id { get; set; }
        public string column_type { get; set; }
        public int number_floors { get; set; }
        public string status { get; set; }
        public string info { get; set; }
        public string notes { get; set; }
        public long battery_id { get; set; }
    }
}
