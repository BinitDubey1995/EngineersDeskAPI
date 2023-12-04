using DatabaseProject.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Helper
{
    public static class IntrigationService
    {
        public static string httpcallingemployeeapi()
        {
            var options = new RestClientOptions("https://dog.ceo")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/api/breeds/image/random", Method.Get);


            var response = client.ExecuteAsync(request).Result;

            return response.Content.ToString();


        }  
    }

       

 }    
    
     

