using DatabaseProject.DatabaseContext;
using DatabaseProject.Interfaces;
using DatabaseProject.Models;
using Intuit.Ipp.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection.Metadata;


namespace DatabaseProject.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly SqlServerContext _SqlServerContext;

        public EmployeeRepository(SqlServerContext sqlServerContext)
        {
            _SqlServerContext = sqlServerContext;
        }


        public List<DEmployee> GetEmployees()
        {
            var lstEmployees = _SqlServerContext.DEmployee.ToList();
            return lstEmployees;
        }

        /// <summary>
        /// Get By Stored Procedure
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //public List<DEmployee> GetEmployees()
        //{
        //    return  _SqlServerContext.DEmployee.FromSqlRaw<DEmployee>("dbo.SP_GET_DEMPLOYEE").ToList();

        //}

        public DEmployee GetEmployeeById(int id)
        {
            var Employee = _SqlServerContext.DEmployee.FirstOrDefault(x => x.EmployeeId == id);
            // var emp = new DEmployeeDetailsResponse() { EmployeeName= Employee.EmpolyeeName,Address= Employee.City + ","+ Employee.Salary}
            return Employee;
        }

        //public String AddEmployee(DEmployee employee)

        //{
        //    _SqlServerContext.DEmployee.Add(employee);
        //    _SqlServerContext.SaveChanges();
        //    return "Success";
        //}

        public String AddEmployee(DEmployee employee)

        {
            var Param = new List<SqlParameter>();
            Param.Add(new SqlParameter("@EmpolyeeName", employee.EmpolyeeName));
            Param.Add(new SqlParameter("@City", employee.City));
            Param.Add(new SqlParameter("@DateofJoining", employee.DateofJoining));
            Param.Add(new SqlParameter("@Salary", employee.Salary));
            Param.Add(new SqlParameter("@IsDelete", employee.IsDelete));

            var result = _SqlServerContext.Database.ExecuteSqlRaw(@"exec dbo.SP_ADD_DEMPLOYEE @EmpolyeeName,@City,@DateofJoining ,@Salary ,@IsDelete", Param.ToArray());
            return "Success";
        }
        //public DEmployee UpdateEmployee(DEmployee employee)
        //{
        //    _SqlServerContext.DEmployee.Update(employee);
        //    _SqlServerContext.SaveChanges();
        //    return employee;
        //}

        public DEmployee UpdateEmployee(DEmployee employee)

        {
            var Param = new List<SqlParameter>();
            Param.Add(new SqlParameter("@EmpolyeeId", employee.EmployeeId));
            Param.Add(new SqlParameter("@City", employee.City));


            var result = _SqlServerContext.Database.ExecuteSqlRaw(@"exec dbo.SP_UPDATE_DEMPLOYEE @EmployeeId,@City", Param.ToArray());
            return employee;
        }


        //public bool DeleteEmployee(int EmployeeId)
        //{
        //    bool result = false;
        //    var employee = _SqlServerContext.DEmployee.Find(EmployeeId);
        //    if (employee != null)
        //    {
        //        _SqlServerContext.Entry(employee).State = EntityState.Deleted;
        //        _SqlServerContext.SaveChanges();
        //        result = true;
        //    }
        //    else
        //    {
        //        result = false;
        //    }
        //    return result;
        //}
        public bool DeleteEmployee(int EmployeeId)
        {
             var result= _SqlServerContext.Database.ExecuteSqlRaw($"DeleteEmployeeById {EmployeeId}");
            return result==0;
        }

        public List<DEmployee> GetEmployeeBySearchKey(string searchkey)

        {
            var employee = _SqlServerContext.DEmployee.Where(x => x.City.Contains(searchkey) || x.EmpolyeeName.Contains(searchkey) || x.Salary.ToString().Contains(searchkey));
            return employee.ToList();
        }
        public bool TemporaryDeleteEmployee(int employeeId)
        {
            var record = new DEmployee() { EmployeeId = employeeId, IsDelete = true };
            _SqlServerContext.Attach(record);
            _SqlServerContext.Entry(record).Property(x => x.IsDelete).IsModified = true;
            _SqlServerContext.SaveChanges();
            return true;
        }

        public EmpAdd SudAddEmpAdd(EmpAdd employee)
        {
            var dEmployee = new DEmployee()
            {
                City = employee.City,
                EmpolyeeName = employee.EmpolyeeName,
                Salary = employee.Salary,
                DateofJoining = employee.DateofJoining
            };
            _SqlServerContext.DEmployee.Add(dEmployee);
            _SqlServerContext.SaveChanges();
            var lastColumn = _SqlServerContext.DEmployee.OrderBy(x => x.EmployeeId).LastOrDefault();

            foreach (var item in employee.AddressList)
            {
                item.EmployeeId = lastColumn.EmployeeId;
                _SqlServerContext.DEmployeeAddress.Add(item);
                _SqlServerContext.SaveChanges();

            }
            return employee;
        }

        public String AddEmployee(TwoTableJoin ttj)

        {
            var Param = new List<SqlParameter>();
            Param.Add(new SqlParameter("@EmpolyeeName", ttj.EmpolyeeName));
            Param.Add(new SqlParameter("@City", ttj.City));
            Param.Add(new SqlParameter("@Salary", ttj.Salary));
            Param.Add(new SqlParameter("@DateofJoining", ttj.DateofJoining));
            Param.Add(new SqlParameter("@IsDelete", ttj.IsDelete));
            Param.Add(new SqlParameter("@EmployeeAddress1", ttj.EmployeeAddress1));
            Param.Add(new SqlParameter("@Zipcode", ttj.Zipcode));
            Param.Add(new SqlParameter("@AddressType", ttj.AddressType));

            var result = _SqlServerContext.Database.ExecuteSqlRaw(@"exec dbo.SP_TwoEmployeeTable @EmpolyeeName,@City,@Salary,@DateofJoining ,@IsDelete,@EmployeeAddress1,@Zipcode,@AddressType", Param.ToArray());
            return "Success";
        }

    }
}



