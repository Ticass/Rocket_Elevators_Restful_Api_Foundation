using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class quotes
    {
        public long id { get; set; }
        public string Full_Name { get; set; }
        public string Phone_Number { get; set; }
        public string Company_Name { get; set; }
        public string Email { get; set; }
        public string Building_Type { get; set; }
        public string Product_Grade { get; set; }
        //public int Nb_Appartement { get; set; }
        //public int Nb_Business { get; set; }
        //public int Nb_Company { get; set; }
        //public int Nb_Floor { get; set; }
        //public int Nb_Basement { get; set; }
       // public int Nb_Cage { get; set; }
        //public int Nb_Parking { get; set; }
        //public int Nb_OccupantPerFloor { get; set; }
        public string Nb_OperatingHour { get; set; }
        public string Nb_Ele_Suggested { get; set; }
        public string Price_Per_Ele { get; set; }
        public string Subtotal { get; set; }
        public string Install_Fee { get; set; }
        public string Final_Price { get; set; }
    }
}
