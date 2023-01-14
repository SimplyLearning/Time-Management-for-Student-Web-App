using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using System.Data.SqlClient;

namespace ST10090436_PROG6212_POEfinal.Pages
{
    public class HoursSpentModel : PageModel
    {
        public String errorMessage = "";
        public String successMessage = "";

        // creating a list of modules
        public List<SelfStudy> selfStudies = new List<SelfStudy>();

        public void OnGet()
        {
            //ModuleCode = Request.Form["ModuleCode"];
            //ModuleName = Request.Form["ModuleName"];
            //NumOfCredits = Request.Form["NumOfCredits"];
            //HoursPerWeek = Request.Form["HoursPerWeek"];
            //StartDate = Request.Form["StartDate"];
            //NumOfWeeks = Request.Form["NumOfWeeks"];

            //error handling
            try
            {
                // CHANGING THIS CONNECTION STRING TO YOUR DATABASE CONNECTION STRING IS NEEDED
                String connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UsersData;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // SQL query
                    
                    String query = "SELECT ModuleCode, ModuleName, NumOfCredits, HoursPerWeek, StartDate, NumOfWeeks, (NumOfCredits * 10 / NumOfWeeks - HoursPerWeek AS  SelfStudyHours) FROM [dbo].[tblModules];";
                    //command.Parameters.AddWithValue("@Username", Username);

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SelfStudy selfList = new SelfStudy();
                                selfList.ModuleCode = reader.GetString(0);
                                selfList.ModuleName = reader.GetString(1);
                                selfList.NumOfCredits = "" + reader.GetInt32(2);
                                selfList.HoursPerWeek = "" + reader.GetInt32(3);
                                selfList.StartDate = reader.GetDateTime(4);
                                selfList.NumOfWeeks = "" + reader.GetInt32(5);
                                //selfList.SelfStudyHours = "" + reader.GetInt32(6);

                                selfStudies.Add(selfList);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Exception: " + ex.ToString());
                errorMessage = ex.Message;
                return;
            }

        }
        // storing data
        public class SelfStudy
        {
            public String ModuleCode;
            public String ModuleName;
            public String NumOfCredits;
            public String HoursPerWeek;
            public DateTime StartDate;
            public String NumOfWeeks;
            //public String SelfStudyHours;

        }
    }
}
