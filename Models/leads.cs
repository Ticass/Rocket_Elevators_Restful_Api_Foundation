using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TodoApi.Models {
     public partial class leads {
    //     public Leads () {
    //         Customers = new HashSet<Customers> ();
    //     }

        public long Id { get; set; }
        public string Full_name { get; set; }
        public string Company_name { get; set; }
         public string Email { get; set; }
        public string Phone { get; set; }
         public string Project_name { get; set; }
         public string Project_desc { get; set; }
        public string Department { get; set; }
        public string Message { get; set; }
        [JsonIgnore]
           public byte[] Attached_file { get; set; }
           public DateTime Created_at { get; set; }
            public DateTime Updated_at { get; set; }
            // public string OriginalFileName { get; set; }
        // [JsonIgnore]
        // public ICollection<Customers> Customers { get; set; }
    }
}