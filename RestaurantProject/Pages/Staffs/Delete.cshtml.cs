using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RestaurantProject.Models;

namespace RestaurantProject.Pages.Staffs
{
    public class DeleteModel : PageModel
    {
        
        [BindProperty]
        public Staff Staffs { get; set; }

        public IConfiguration Configuration { get; set; }

        private string connStr;

        public DeleteModel(IConfiguration configuration)
        {
            Configuration = configuration;
            connStr = configuration["ConnectionStrings:RestaurantProjectContext"];
        }

        public IActionResult OnGet(int? id)
        {
            Console.WriteLine("Delete page : " + id);
            string DbConnection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Staffs;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            
            SqlConnection conn = new SqlConnection(DbConnection);
            conn.Open();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conn;
                command.CommandText = "SELECT * FROM Staffs WHERE StaffID = @SID";
                command.Parameters.AddWithValue("@SID", id);

                SqlDataReader reader = command.ExecuteReader();
                Models.Staff rec = new Models.Staff(); //a local var to hold a record temporarily
                while (reader.Read())
                {
                    rec.Id = reader.GetInt32(0);
                    rec.StaffID = reader.GetString(1);
                    rec.StaffFname = reader.GetString(2);
                    rec.StaffLname = reader.GetString(3);
                    rec.StaffSex = reader.GetString(4);
                    rec.StaffEmail = reader.GetString(5);
                    rec.Stafftype = reader.GetString(6);
                    rec.Staffnationality = reader.GetString(7);
                    rec.Staffpassword = reader.GetString(8);
                }

            }

            conn.Close();

            return Page();
        }


        public IActionResult OnPost()
        {
            string DbConnection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Staffs;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conn;
                command.CommandText = "DELETE Staffs WHERE StaffID = @SID";
                command.Parameters.AddWithValue("@SID", Staffs.Id);
                command.ExecuteNonQuery();
            }

            conn.Close();
            return RedirectToPage("./Index");
        }
        
    }
}