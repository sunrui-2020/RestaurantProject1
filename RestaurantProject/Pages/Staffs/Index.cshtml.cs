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
   
             public class IndexModel : PageModel
    {
            [BindProperty]
            public Staff Staffs { get; set; }
            public void OnGet()
            {
            }
            public IActionResult OnPost()
            {
                string DbConnection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Staffs;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                SqlConnection conn = new SqlConnection(DbConnection);
                conn.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = @"INSERT INTO Staffs (StaffID, StaffFName, StaffLname, StaffSex,StaffEmail,Stafftype,Staffnationality,Staffpassword) VALUES (@SID, @SFName, @SLname, @SSex,@SEmail,@Stype,@Snationality,@SPassword)";

                    command.Parameters.AddWithValue("@SID", Staffs.StaffID);
                    command.Parameters.AddWithValue("@SFName", Staffs.StaffFname);
                    command.Parameters.AddWithValue("@SLname", Staffs.StaffLname);
                    command.Parameters.AddWithValue("@SSex", Staffs.StaffSex);
                    command.Parameters.AddWithValue("@SEmail", Staffs.StaffEmail);
                    command.Parameters.AddWithValue("@Stype", Staffs.Stafftype);
                    command.Parameters.AddWithValue("@Snationality", Staffs.Staffnationality);
                    command.Parameters.AddWithValue("@SPassword", Staffs.Staffpassword);


                    Console.WriteLine(Staffs.StaffID);
                    Console.WriteLine(Staffs.StaffFname);
                    Console.WriteLine(Staffs.StaffLname);
                    Console.WriteLine(Staffs.StaffSex);
                    Console.WriteLine(Staffs.StaffEmail);
                    Console.WriteLine(Staffs.Stafftype);
                    Console.WriteLine(Staffs.Staffnationality);
                    Console.WriteLine(Staffs.Staffpassword);






                    command.ExecuteNonQuery();

                }



                return RedirectToPage("/Index");
            }


        }
    }
 