using DatabaseProject.Entity_Model;
using DatabaseProject.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Helper
{
    public static class TPCalling
    {
        public static string httpcallingaddemployeeapi(DEmployee tpc)
        {
            var options = new RestClientOptions("https://localhost:7211")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/api/Employee/AddEmployee", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            //request.AddJsonBody(new { employeeId = 0, empolyeeName = "bar", city= "swarg", dateofJoining= "2060-05-14T05:18:35.185Z", salary=50000, isDelete=true });
            request.AddJsonBody(new { employeeId = 0, empolyeeName = tpc.EmpolyeeName , city = tpc.City, dateofJoining = tpc.DateofJoining, salary = tpc.Salary, isDelete = tpc.IsDelete });

            var  response =  client.ExecuteAsync(request).Result;
            return response.Content.ToString();

        }
    }
}
