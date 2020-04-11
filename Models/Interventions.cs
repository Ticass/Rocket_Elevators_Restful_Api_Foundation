using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class Interventions
    {
        public long id { get; set; }

        public long employee_id { get; set; }
        public long building_id { get; set; }
        public long battery_id { get; set; }

        //public long column_id { get; set; }
        //public long elevator_id { get; set; }
        public string intervention_start_date { get; set; }
        public string intervention_end_date { get; set; }
        public string intervention_result { get; set; }
        public string intervention_report { get; set; }
        public string intervention_status { get; set; }
    }
}
