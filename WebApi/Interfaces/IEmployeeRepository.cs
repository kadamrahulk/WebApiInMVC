using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;

namespace WebApi.Interfaces
{
  public  interface IEmployeeRepository
    {
        
        IQueryable<Employee> GetEmployees();

        [ResponseType(typeof(Employee))]
        Employee GetEmployee(int id);
        void PutEmployee(int id, ref Employee employee);

        [ResponseType(typeof(Employee))]
        void PostEmployee(ref Employee employee);
        [ResponseType(typeof(Employee))]
        Employee DeleteEmployee(int id);
        bool EmployeeExists(int id);
        void Dispose();
    }
}
