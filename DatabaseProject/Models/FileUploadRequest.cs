using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Models
{
   
        
    public class FileUploadRequest
        {
            public IFormFile FileDetails { get; set; }
            
        }
    
}

