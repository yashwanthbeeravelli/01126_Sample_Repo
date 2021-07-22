using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KudVenkat.Models
{
    public interface IEmployeeRepository
    {
        Employee GetEmployeeById(int id);
    }
}
