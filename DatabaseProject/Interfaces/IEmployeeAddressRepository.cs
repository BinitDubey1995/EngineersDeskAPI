using DatabaseProject.Entity_Model;
using DatabaseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Interfaces
{
    public interface IEmployeeAddressRepository
    {
        DEmployeeDetailsResponse GetEmployeeDetailsResponseById(int Id);
        DEmployeeDetailAddress GetAddressDetailsResponseById(int Id);

         

        Cities GetCitiesById(int StateID);

        CreateAddressResponse AddEAddress(CreateAddressRequest employee);
    }
}
