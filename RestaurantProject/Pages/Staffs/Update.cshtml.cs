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
    public class UpdateModel : PageModel
    {
        [BindProperty]
        public Staff Staffs { get; set; }

        public IActionResult OnGet(int? id)
        {
            string DbConnection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Staffs;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection conn = new SqlConnection(DbConnection);
            conn.Open();



            Staffs = new Staff();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conn;
                command.CommandText = "SELECT * FROM Staffs WHERE Id = @ID";

                command.Parameters.AddWithValue("@ID", id);
                Console.WriteLine("The Id : " + id);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Staffs.Id = reader.GetInt32(0);
                    Staffs.StaffFname = reader.GetString(1);
                    Staffs.StaffLname = reader.GetString(2);
                    Staffs.StaffSex = reader.GetString(3);
                    Staffs.StaffEmail = reader.GetString(4);
                    Staffs.Stafftype = reader.GetString(5);
                    Staffs.Staffnationality = reader.GetString(6);
                    Staffs.Staffpassword = reader.GetString(7);

                }


            }

            conn.Close();

            return Page();

        }


        public IActionResult OnPost()
        {
            string DbConnection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RestaurantProjectContext-ade90079-b59c-4bda-bb92-7083d6d87e69;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection conn = new SqlConnection(DbConnection);
            conn.Open();

            Console.WriteLine("Staff ID : " + Staffs.Id);
            Console.WriteLine("First name: " + Staffs.StaffFname);
            Console.WriteLine("Last name : " + Staffs.StaffLname);
            Console.WriteLine("Sex : " + Staffs.StaffSex);
            Console.WriteLine("Email : " + Staffs.StaffEmail);
            Console.WriteLine("job type: " + Staffs.Stafftype);
            Console.WriteLine("Nationality : " + Staffs.Staffnationality);
            Console.WriteLine("staff password : " + Staffs.Staffpassword);

            using (SqlCommand command = new SqlCommand())
            {
                command.CommandText = @"INSERT INTO Staffs (StaffID, StaffFName, StaffLname, StaffSex,StaffEmail,Stafftype,Staffnationality,Staffpassword) VALUES (@SID, @SFName, @SLname, @SSex,@SEmail,@Stype,@Snationality,@SPassword)";

                command.Parameters.AddWithValue("@SID", Staffs.StaffID);
                command.Parameters.AddWithValue("@SFName", Staffs.StaffFname);
                command.Parameters.AddWithValue("@SLname", Staffs.StaffLname);
                command.Parameters.AddWithValue("@SSex", Staffs.StaffSex);
                command.Parameters.AddWithValue("@SEmail", Staffs.StaffEmail);
                command.Parameters.AddWithValue("@Stype", Staffs.Stafftype);
                command.Parameters.AddWithValue("@Snationality", Staffs.Staffnationality);
                command.Parameters.AddWithValue("@SPassword", Staffs.Staffpassword);
            }

            conn.Close();

            return RedirectToPage("/Index");
        }

    }
}



