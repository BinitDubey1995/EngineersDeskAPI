using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Models
{
    public class CreateAddressRequest
    {
        public int EmployeeId { get; set; }
        public string ? EmployeeAddress1 { get; set; }

        public int Zipcode { get; set; }
    }
}
