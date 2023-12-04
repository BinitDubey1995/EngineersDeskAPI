using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Models
{
    public class DEmployeeAddress
    {
       [Key] 
        
       [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        
        public int  Id { get; set; }

        public string EmployeeAddress1 { get; set; }

        public string City { get; set; }

        public int Zipcode { get; set; }

        public string AddressType { get; set; }

        public int ? EmployeeId { get; set; }
    }
}
