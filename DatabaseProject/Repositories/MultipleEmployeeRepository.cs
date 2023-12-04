using DatabaseProject.DatabaseContext;
using DatabaseProject.Entity_Model;
using DatabaseProject.Interfaces;
using DatabaseProject.Models;
using Intuit.Ipp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Repositories
{
    public class MultipleEmployeeRepository : IMultipleEmployeeRepository
    {
        private readonly SqlServerContext _SqlServerContext;

        public MultipleEmployeeRepository(SqlServerContext sqlServerContext)
        {
            _SqlServerContext = sqlServerContext;
        }

        public List<DEmployee> AddEmployee(MultipleEmployee employee)

        {
            foreach (var item in employee.Employees)
            {
                _SqlServerContext.DEmployee.Add(item);
                _SqlServerContext.SaveChanges();
            }
            
            return employee.Employees;
        }
        // public String DeleteEmployee(List<int> EmployeeId)
        public String DeleteEmployee(string EmployeeId)
        {
            foreach (var item in EmployeeId)
            {    
                var itemint = Convert.ToInt32(item);
                _SqlServerContext.DEmployee.Find(item);
                _SqlServerContext.SaveChanges();
            }
            return "success";
        }
    }
}
