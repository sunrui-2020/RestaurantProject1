using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantProject.Models;

namespace RestaurantProject.Data
{
    public class RestaurantProjectContext : DbContext
    {
        public RestaurantProjectContext (DbContextOptions<RestaurantProjectContext> options)
            : base(options)
        {
        }

        public DbSet<RestaurantProject.Models.Customer> Customer { get; set; }
    }
}
