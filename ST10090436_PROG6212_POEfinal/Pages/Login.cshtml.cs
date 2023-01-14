using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using System.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ST10090436_PROG6212_POEfinal.Pages
{
    public class LoginModel : PageModel
    {
        public String errorMessage = "";
        public String successMessage = "";

        public string username { get; set; }
        public string password { get; set; }
        public int userId { get; set; }

        public void OnGet()
        { 
        }
        public void OnPost() {

            username = Request.Form["txtUsername"];
            password = Request.Form["txtPassword"];

            // error handling
            try
            {
                // CHANGING THIS CONNECTION STRING TO YOUR DATABASE CONNECTION STRING IS NEEDED
                SqlConnection sqlCon = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UsersData;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                
                sqlCon.Open();

                // creating the query
                String query = $"SELECT * FROM [dbo].[tblUser] WHERE Username = '{username}' AND Password = '{password}'";

                using (SqlCommand command = new SqlCommand(query, sqlCon))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                       while (reader.Read())
                       {
                            username = (string)reader[0];
                            password = (string)reader[1];
                            //userId = Convert.ToInt32(reader[0]);

                       }
                    }
                    sqlCon.Close();
                }

                if (username == "")
                {
                    errorMessage = "All the Fields are Required!";
                    return;
                }
            }

            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            successMessage = "Login Successful!";
            
            // redirecting user 
            Response.Redirect("/Modules");

        }
    }
}

