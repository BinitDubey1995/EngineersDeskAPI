using DatabaseProject.Entity_Model;
using DatabaseProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace DatabaseProject.Interfaces
{
    public interface IUsersRepository
    {
       


        Users AddUser(Users user);

        Users GetByusername(string username);

        bool GetByVerifyingmail(Verifyingmail verifyingmail);


        DEmployeeFileDetails AddPostSingleFile(DEmployeeFileDetails fileDetails);

        DEmployeeFileDetails GetFilebyID(int ID);




      
        
    }
}
