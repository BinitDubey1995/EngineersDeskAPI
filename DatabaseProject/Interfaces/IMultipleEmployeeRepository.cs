using DatabaseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Interfaces
{
    public interface IMultipleEmployeeRepository
    {
        List<DEmployee> AddEmployee(MultipleEmployee entity);

        //public String DeleteEmployee(List<int> employeeId);

        public String DeleteEmployee(string employeeId);
    }
}
