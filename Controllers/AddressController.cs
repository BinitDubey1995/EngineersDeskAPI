using DatabaseProject.Interfaces;
using DatabaseProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EngineersDeskAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IEmployeeAddressRepository _EmployeeAddressRepository;
        //private readonly object? addedemployee;

        public AddressController(IEmployeeAddressRepository employeeaddressRepository)

        {
            _EmployeeAddressRepository = employeeaddressRepository;
        }
        [HttpGet]

        public ActionResult GetEmployeeDetailsResponseById(int Id)
        {
            try
            {
                var employee = _EmployeeAddressRepository.GetEmployeeDetailsResponseById(Id);
                if (employee == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Not Exist");
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }
        [HttpGet]

        public ActionResult GetAddressDetailResponseById(int Id)
        {
            try
            {
                var employee = _EmployeeAddressRepository.GetAddressDetailsResponseById(Id);
                if (employee == null)

                {

                    return StatusCode(StatusCodes.Status404NotFound, "Not Exist");
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }
        [HttpGet]

        public ActionResult GetCitiesById(int StateID)
        {
            try
            {
                var cities = _EmployeeAddressRepository.GetCitiesById(StateID);
                if (cities == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Not Exist");
                }
                return Ok(cities);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }
            [HttpPost]
            [Route("CreateAddressRequest")]

            public ActionResult AddEAddress(CreateAddressRequest employee)
            {
                try
                {
                    if (employee.Zipcode.ToString().Count() != 6)

                    {
                        return Ok("This code is invalid,Please enter six digits number");
                    };



                    var CreateRA = _EmployeeAddressRepository.AddEAddress(employee);
                    return Ok("CreateRA");
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
                }

            }
        }
    }
    

