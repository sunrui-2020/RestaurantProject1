using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantProject.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Display(Name = "Membership ID")]
        [Required]
        public string CustomerID { get; set; }

        [Display(Name = "Firstname")]
        [Required]
        public string CustomerFname { get; set; }

        [Display(Name = "Lastname")]
        [Required]
        public string CustomerLname { get; set; }

        [Display(Name = "Sex")]
        [Required]
        public string CustomerSex { get; set; }

        [Display(Name = "Customer Email")]
        public string CustomerEmail { get; set; }

        [Display(Name = "Telephone")]
        [Required]
        public string Customerphone { get; set; }

        [Display(Name = "Password")]
        public string CustomerPwd { get; set; }
    }
}
