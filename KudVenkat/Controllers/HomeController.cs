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
            return _employeeRepository.GetEmployeeById(1).Name;        
        }
            
        /* This function returns the data in ViewBag */
        public ViewResult Details()
        {
            Employee model = _employeeRepository.GetEmployeeById(2);
            ViewBag.Employee = model;
            ViewBag.PageTitle = "Employee Info from ViewBag";
            return View(model);
        }
    }
}
