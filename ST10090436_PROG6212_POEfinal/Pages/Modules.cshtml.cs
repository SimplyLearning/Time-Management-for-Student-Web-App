using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ST10090436_PROG6212_POEfinal.Pages
{
    public class ModulesModel : PageModel
    {
        public String errorMessage = "";
        public String successMessage = "";

        // creating a list of modules
        public List<ModuleInfo> moduleList = new List<ModuleInfo>();

        public void OnGet()
        {
            //String Username = Request.Query["Username"];
            //error handling
            try
            {
                // CHANGING THIS CONNECTION STRING TO YOUR DATABASE CONNECTION STRING IS NEEDED
                String connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UsersData;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // SQL query
                    String query = "SELECT * FROM [dbo].[tblModules];";
                    //command.Parameters.AddWithValue("@Username", Username);
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ModuleInfo moduleInfo = new ModuleInfo();
                                moduleInfo.ModuleCode = (string)reader[0];
                                moduleInfo.ModuleName = (string)reader[1];
                                moduleInfo.NumOfCredits = Convert.ToInt32(reader[2]);
                                moduleInfo.HoursPerWeek = Convert.ToInt32(reader[3]);
                                moduleInfo.StartDate = (DateTime)reader[4];
                                moduleInfo.NumOfWeeks = Convert.ToInt32(reader[5]);

                                moduleList.Add(moduleInfo);
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
        public void OnPost()
        {

        }
    }
        // storing data
        public class ModuleInfo 
        {
            public String ModuleCode {  get; set; }
            public  String ModuleName { get; set; }
            public int NumOfCredits { get; set; }
            public  int HoursPerWeek { get; set; }
            public DateTime StartDate { get; set; }
            public int NumOfWeeks { get; set; }

    }
}
