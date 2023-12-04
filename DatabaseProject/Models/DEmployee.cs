using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Models
{
    public class DEmployee
    {
        public int EmployeeId { get; set; }
        //for checking empty string by DataAnnotations
        //[Required(AllowEmptyStrings = false)]
        public string ? EmpolyeeName { get; set; }

        public string ? City { get; set; }

        public DateTime DateofJoining { get; set; }

        public decimal Salary { get; set; }

        public bool IsDelete { get; set; }

        

       
    }
}
