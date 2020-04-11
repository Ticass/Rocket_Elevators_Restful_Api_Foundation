using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TodoApi.Models
{
    public class employees
    {
        public long id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string title { get; set; }
        public string email { get; set; }
        public string encrypted_password { get; set; }
        public string reset_password_token { get; set; }

        [JsonIgnore]
        public DateTime reset_password_sent_at { get; set; }
        public DateTime remember_created_at { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        


    }
}
