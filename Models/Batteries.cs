using System;
using System.Collections.Generic;

namespace TodoApi.Models {
    public class batteries {
        

        public long id { get; set; }
        public string Status { get; set; }
        public string  battery_type { get; set; }
        public DateTime  date_commision { get; set; }
        public DateTime date_last_inspect { get; set; }
        
        // public long EmployeeId { get; set; }
        // public DateTime? InServiceSince { get; set; }
        // public DateTime? LastInspection { get; set; }
        // public string OperationsCertificate { get; set; }
        // public string Information { get; set; }
        // public string Notes { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

        // public Buildings Building { get; set; }
        // public Employees Employee { get; set; }
        // public ICollection<Columns> Columns { get; set; }
    }
}