using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KudVenkat.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        public List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>() {
            new Employee() { Department= "HR", Email= "abc@gmail.com", ID=1, Name="Jen Chaitman" },
            new Employee() { Department= "IT", Email= "def@hotmail.com", ID=2, Name="Veronique" },
            new Employee() { Department= "Sales", Email= "gef@ymail.com", ID=3, Name="Susan" }
            };
        }
        public Employee GetEmployeeById(int id)
        {
            return _employeeList.FirstOrDefault(x => x.ID == id);
        }
    }
}
