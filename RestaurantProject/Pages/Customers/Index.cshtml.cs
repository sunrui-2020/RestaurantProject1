using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestaurantProject.Data;
using RestaurantProject.Models;

namespace RestaurantProject.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly RestaurantProject.Data.RestaurantProjectContext _context;

        public IndexModel(RestaurantProject.Data.RestaurantProjectContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; }

        public async Task OnGetAsync()
        {
            Customer = await _context.Customer.ToListAsync();
        }
    }
}
