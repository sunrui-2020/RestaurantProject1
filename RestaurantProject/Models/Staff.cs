using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantProject.Models
{
    public class Staff
    {
        internal static bool StaffUsername;

        public int Id { get; set; }

        public string StaffID { get; set; }

        public string StaffFname { get; set; }

        public string StaffLname { get; set; }

        public string StaffSex { get; set; }

        public string StaffEmail { get; set; }

        public string Stafftype { get; set; }

        public string Staffnationality { get; set; }

        public string Staffpassword { get; set; }
    

    }
}

