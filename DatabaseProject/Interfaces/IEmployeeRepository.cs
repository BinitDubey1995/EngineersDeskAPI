using DatabaseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Interfaces
{
    public interface IEmployeeRepository
    {


        List<DEmployee> GetEmployees();

        DEmployee GetEmployeeById(int employeeId);

        String AddEmployee(DEmployee employee);

       DEmployee UpdateEmployee(DEmployee Employee);

        //bool DeleteEmployee(int employeeId);

        bool DeleteEmployee(int employeeId);

        List<DEmployee> GetEmployeeBySearchKey(String searchkey);

        bool TemporaryDeleteEmployee(int employeeId);

        EmpAdd SudAddEmpAdd(EmpAdd employee);

        String AddEmployee(TwoTableJoin ttj);

    }
   
}
