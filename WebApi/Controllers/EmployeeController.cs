using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.BusinessClasses;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        IEmployeeRepository repositoryEmployee;

        public EmployeeController()
        {
            repositoryEmployee = new EmployeeRepository();
        }
        // GET api/Employee
        public IQueryable<Employee> GetEmployees()
        {
          return  repositoryEmployee.GetEmployees();
        }

        // GET api/Employee/5
        [ResponseType(typeof(Employee))]
        public IHttpActionResult GetEmployee(int id)
        {
            Employee employee = repositoryEmployee.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT api/Employee/5
        public IHttpActionResult PutEmployee(int id, Employee employee)
        {

            if (id != employee.EmployeeID)
            {
                return BadRequest();
            }

            try
            {
                repositoryEmployee.PutEmployee(id,ref employee);
            }
            //DbUpdateConcurrencyException
            catch (Exception ex)
            {
                if (repositoryEmployee.EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest();
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Employee
        [ResponseType(typeof(Employee))]
        public IHttpActionResult PostEmployee(Employee employee)
        {
            try
            {
                repositoryEmployee.PostEmployee(ref employee);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            return CreatedAtRoute("DefaultApi", new { id = employee.EmployeeID }, employee);
        }

        // DELETE api/Employee/5
        [ResponseType(typeof(Employee))]
        public IHttpActionResult DeleteEmployee(int id)
        {
         Employee employee = repositoryEmployee.DeleteEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repositoryEmployee.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeExists(int id)
        {
            return repositoryEmployee.EmployeeExists(id);
        }
    }
}