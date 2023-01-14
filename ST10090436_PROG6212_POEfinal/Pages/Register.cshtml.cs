using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ST10090436_PROG6212_POEfinal.Pages
{
    public class RegisterModel : PageModel
    {
        public String errorMessage = "";
        public String successMessage = "";
        // creating a list of modules
        //public List<UserLogin> userList = new List<UserLogin>();
        //public UserLogin userInfo = new UserLogin();

        public string username { get; set; }
        public string password { get; set; }

        public void OnGet()
        {

        }
        public void OnPost()
        {

            username = Request.Form["txtUsername"];
            password = Request.Form["txtPassword"];


            // saving the data into the database
            try
            {
                // CHANGING THIS CONNECTION STRING TO YOUR DATABASE CONNECTION STRING IS NEEDED
                String connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UsersData;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    
                    String query = $"INSERT INTO [dbo].[tblUser] VALUES('{username}','{password}')";
                    //connection.Open();
                    using (SqlCommand sqlCmd = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        sqlCmd.ExecuteNonQuery();
                        
                    }
                }
                
                //if (userInfo.Username == "" || userInfo.Password == "")
                //{
                //    errorMessage = "All the Fields are Required!";
                //    return;
                //} else
                //{
                //    successMessage = "New User Successfuly Registered!";
                //    Response.Redirect("/Login");
                //}

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }


           // userInfo.Username = "";
            // userInfo.Password = "";

            successMessage = "New User Successfuly Registered!";

            // redirecting user 
            Response.Redirect("/Login");

        }
    }
    
}
