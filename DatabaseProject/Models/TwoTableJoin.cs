using DatabaseProject.Entity_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Models
{
    public class TwoTableJoin
    {
        public string? EmpolyeeName { get; set; }

        public string? City { get; set; }


        public decimal Salary { get; set; }

        public DateTime DateofJoining { get; set; }

        public bool IsDelete { get; set; }

        public string EmployeeAddress1 { get; set; }


        public int Zipcode { get; set; }

        public string AddressType { get; set; }


    }
}
