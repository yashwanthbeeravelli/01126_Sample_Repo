using KudVenkat.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KudVenkat.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        
        public string Index()
        {
            return _employeeRepository.GetEmployeeById(2).Name;        
        }
            
        /* This function returns the data in ViewData */
        public ViewResult Details()
        {
            Employee employee = _employeeRepository.GetEmployeeById(1);
            ViewData["Employee"] = employee;
            ViewData["PageTitle"] = "Employee Info from ViewData";
            return View(employee);
        }
    }
}
