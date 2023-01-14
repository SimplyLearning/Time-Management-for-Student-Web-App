using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ST10090436_PROG6212_POEfinal.Pages
{
    public class AddModulesModel : PageModel
    {
        public String errorMessage = "";
        public String successMessage = "";
        // creating a list of modules
        public String ModuleCode { get; set; }
        public String ModuleName { get; set; }
        public int NumOfCredits { get; set; }
        public int HoursPerWeek { get; set; }
        public DateTime StartDate { get; set; }
        public int NumOfWeeks { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            ModuleCode = Request.Form["ModuleCode"];
            ModuleName = Request.Form["ModuleName"];
            NumOfCredits = Convert.ToInt32(Request.Form["NumOfCredits"]);
            HoursPerWeek = Convert.ToInt32(Request.Form["HoursPerWeek"]);
            StartDate = Convert.ToDateTime(Request.Form["StartDate"]);
            NumOfWeeks = Convert.ToInt32(Request.Form["NumOfWeeks"]);


            // error handling
            try
            {
                // CHANGING THIS CONNECTION STRING TO YOUR DATABASE CONNECTION STRING IS NEEDED
                String connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UsersData;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    //connection.Open();
                    //String query = "INSERT INTO [dbo].[tblModules](ModuleCode, ModuleName, NumOfCredits, HoursPerWeek, StartDate, NumOfWeeks) VALUES (@ModuleCode, @ModuleName, @NumOfCredits, @HoursPerWeek, @StartDate, @NumOfWeeks );";
                    String query = $"INSERT INTO [dbo].[tblModules] VALUES ('{ModuleCode}', '{ModuleName}', '{NumOfCredits}', '{HoursPerWeek}', '{StartDate.ToShortDateString()}', '{NumOfWeeks}')";

                    using (SqlCommand sqlCmd = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        sqlCmd.ExecuteNonQuery();
                    }
                }
                // error message 

                if (ModuleCode == "" ||
                    ModuleName == "")
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

            successMessage = "New Module Added Correctly!";

            // redirecting user 
            Response.Redirect("/Modules");

        }
    }
}
