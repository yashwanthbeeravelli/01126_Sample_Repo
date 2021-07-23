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
            //return "Hello World. This is from MVC HomeController";
        }
        /*
        public IActionResult Index()
        {
            return View();
        }
        */

        /* The below code returns the result in a Json Format. Typically used for Web APIs, REST Services */
        public JsonResult JsonDetails()
        {
            Employee model = _employeeRepository.GetEmployeeById(3);
            return Json(model);
        }

        /* The below code returns the result in a XML Format. */
        public ObjectResult ObjDetails()
        {
            Employee model = _employeeRepository.GetEmployeeById(3);
            return new ObjectResult(model);
        }
    }
}
