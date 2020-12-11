using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using RestaurantProject.Models;

namespace RestaurantProject.Pages.Staffs
{
    public class ViewModel : PageModel
    {
        public List<Models.Staff> RestaurantProject { get; private set; }

        public IActionResult OnGet()
        {

            string DbConnection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Staffs;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conn = new SqlConnection(DbConnection);
            conn.Open();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conn;
                command.CommandText = @"SELECT * FROM Staffs ORDER BY StaffFname"; // try order by Name

                SqlDataReader reader = command.ExecuteReader();

                RestaurantProject = new List<Models.Staff>();
                // Call Read before accessing data.
                while (reader.Read())//keep reading while there is a record
                {
                    Models.Staff rec = new Models.Staff(); //a local var to hold a record temporarily
                    rec.Id = reader.GetInt32(0);
                    rec.StaffID = reader.GetString(1); //make sure the data type is matched
                    rec.StaffFname = reader.GetString(2);
                    rec.StaffLname = reader.GetString(3);
                    rec.StaffSex = reader.GetString(4);
                    rec.StaffEmail = reader.GetString(5);
                    rec.Stafftype = reader.GetString(6);
                    rec.Staffnationality = reader.GetString(7);


                    RestaurantProject.Add(rec); //the temporary var of rec which consists of a record is added to the the list

                }

                // Call Close when done reading.
                reader.Close();
            }
            return Page();//return to the page after the result is obtained
        }
    }
}