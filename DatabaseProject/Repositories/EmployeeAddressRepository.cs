using DatabaseProject.DatabaseContext;
using DatabaseProject.Entity_Model;
using DatabaseProject.Interfaces;
using DatabaseProject.Models;
using Intuit.Ipp.OAuth2PlatformClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Repositories
{
    public class EmployeeAddressRepository : IEmployeeAddressRepository
    {
        private readonly SqlServerContext _SqlServerContext;

        public EmployeeAddressRepository(SqlServerContext sqlServerContext)
        {
            _SqlServerContext = sqlServerContext;
        }
        public DEmployeeDetailsResponse GetEmployeeDetailsResponseById(int Id)
        {
            var EmployeeDetails = _SqlServerContext.DEmployee.FirstOrDefault(x => x.EmployeeId == Id);
            var EmployeeDetail = _SqlServerContext.DEmployeeAddress.FirstOrDefault(x => x.EmployeeId == Id);

            var emp = new DEmployeeDetailsResponse() { EmployeeName = EmployeeDetails.EmpolyeeName, Salary = EmployeeDetails.Salary, AddressType = EmployeeDetail.AddressType, EmployeeAddress = EmployeeDetail.EmployeeAddress1 + "," + EmployeeDetail.Zipcode };
            return emp;
        }
        public DEmployeeDetailAddress GetAddressDetailsResponseById(int Id)
        {
            var EmployeeDetails = _SqlServerContext.DEmployee.FirstOrDefault(x => x.EmployeeId == Id);
            var EmployeeDetail = _SqlServerContext.DEmployeeAddress.Where(x => x.EmployeeId == Id).ToList();

            var emp = new DEmployeeDetailAddress()
            {
                EmployeeName = EmployeeDetails.EmpolyeeName,
                Salary = EmployeeDetails.Salary,
                AddressList = EmployeeDetail.Select(x => new EAddress() { AddressType = x.AddressType, EmployeeAddress = x.EmployeeAddress1 + "," + x.Zipcode }).ToList(),
            };

            return emp;
        }
        public Cities GetCitiesById(int StateID)
        {
            var StateDetails = _SqlServerContext.StateLookup.FirstOrDefault(x => x.StateID == StateID);
            var CitiesName = _SqlServerContext.all_cities.Where(x => x.StateID == StateID).ToList();

            var emp = new Cities()
            {

                StateID = StateDetails.StateID,
                StateName = StateDetails.StateName,
                StateAbbrev = StateDetails.StateAbbrev,
                Address = StateDetails.StateName + "," + CitiesName[0].cityname,


                all_cities = CitiesName.Select(x => new all_cities() { cityId = x.cityId, cityname = x.cityname, StateID = x.StateID }).ToList(),
            };
            return emp;
        }
        public CreateAddressResponse AddEAddress(CreateAddressRequest employee)

        {
            var EAddress = new DEmployeeAddress() {EmployeeId= 2 , Zipcode = employee.Zipcode, EmployeeAddress1 = employee.EmployeeAddress1 };
            _SqlServerContext.DEmployeeAddress.Add(EAddress);
            _SqlServerContext.SaveChanges();
           var CreateRA= new CreateAddressResponse() { Zipcode=employee.Zipcode};
            return CreateRA;

        }
    }
}
