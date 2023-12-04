using DatabaseProject.DatabaseContext;
using DatabaseProject.Entity_Model;
using DatabaseProject.Interfaces;
using DatabaseProject.Models;
using Intuit.Ipp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly SqlServerContext _SqlServerContext;

        public UsersRepository(SqlServerContext sqlServerContext)
        {
            _SqlServerContext = sqlServerContext;
        }




        public Users AddUser(Users user)

        {
            _SqlServerContext.UsersTbls.Add(user);
            _SqlServerContext.SaveChanges();
            return user;
        }
        public Users GetByusername(string username)
        {
            var user = _SqlServerContext.UsersTbls.FirstOrDefault(x => x.username == username);
            return user;
        }

        public bool GetByVerifyingmail(Verifyingmail v)

        {
            int user = _SqlServerContext.UsersTbls.Count(x => x.email == v.email && x.password == v.password);

            if (user > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public DEmployeeFileDetails AddPostSingleFile(DEmployeeFileDetails fileDetails)

        {
            _SqlServerContext.DEmployeeFileDetails.Add(fileDetails);
            _SqlServerContext.SaveChanges();
            return fileDetails;
        }
        public DEmployeeFileDetails GetFilebyID(int ID)
        {
            var file = _SqlServerContext.DEmployeeFileDetails.FirstOrDefault(x => x.ID == ID);
            return file;
        }

        
    }
}

    




