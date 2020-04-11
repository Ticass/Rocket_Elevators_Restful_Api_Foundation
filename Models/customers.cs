using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TodoApi.Models
{
    public class customers
    {
        public long id { get; set; }
        public DateTime customer_create_date { get; set; }
        public string company_name { get; set; }
        public string name_company_contact { get; set; }
        public string company_phone { get; set; }
        public string contact_email { get; set; }
        public string company_desc { get; set; }
        public string full_name_STA { get; set; }
        public string tech_authority_phone { get; set; }
        public string tech_manager_email { get; set; }
        public long address_id { get; set; }
        [JsonIgnore]
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

    }
}
