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
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.BusinessClasses
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private DBModel db = new DBModel();
       public IQueryable<Employee> GetEmployees()
        {
            return db.Employees;
        }

        [ResponseType(typeof(Employee))]
      public  Employee GetEmployee(int id)
        {
            Employee employee = db.Employees.Find(id);
            return employee;
        }

       public void PutEmployee(int id, ref Employee employee)
        {
            db.Entry(employee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }

            catch(Exception ex)
            {
                throw ex;
            }
            
        }


        [ResponseType(typeof(Employee))]
        public void PostEmployee(ref Employee employee)
        {
            try
            {
                db.Employees.Add(employee);
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [ResponseType(typeof(Employee))]
      public  Employee DeleteEmployee(int id)
        {
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return employee;
            }
            db.Employees.Remove(employee);
            db.SaveChanges();
            return employee;
        }

        

      public  bool EmployeeExists(int id)
        {
            return db.Employees.Count(e => e.EmployeeID == id) > 0;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}