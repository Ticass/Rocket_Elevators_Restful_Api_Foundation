using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class users
    {
        public long id { get; set; }
        public string email { get; set; }
        public string encrypted_password { get; set; }
        public string reset_password_token { get; set; }
        public long employee_id { get; set; }
        public long customer_id { get; set; }

    }
}
