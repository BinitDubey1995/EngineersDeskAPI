using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Models
{
    public class DEmployeeDetailsResponse
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }

        public decimal Salary { get; set; }

        public string EmployeeAddress { get; set; }

        public string AddressType { get; set; }
    }
}
