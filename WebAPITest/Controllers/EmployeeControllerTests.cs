using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers.Tests
{
    [TestClass()]
    public class EmployeeControllerTests
    {
        EmployeeController objEmployeeController = new EmployeeController();
        [TestMethod()]
        public void GetEmployeesTest()
        {
            try
            {

                Employee tmpEmployee = new Employee();
                Employee tmpEmployee1 = new Employee();
                tmpEmployee.Name = "rahul";
                tmpEmployee.EmailID = "kadam1ra1hu1lk1@gmail.com";
                tmpEmployee.PhoneNumber = "2222332222222";
                objEmployeeController.PutEmployee(0, tmpEmployee);
                IEnumerable<Employee> employees = objEmployeeController.GetEmployees();
                bool t = employees.Contains(tmpEmployee1);
                bool result = (employees.Count()>0);
                Assert.IsTrue(result);
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void GetEmployeeTest()
        {
            
            Assert.Fail();
        }

        [TestMethod()]
        public void PutEmployeeTest()
        {
            Employee tmpEmployee = new Employee();
            tmpEmployee.Name = "rahul";
            tmpEmployee.EmailID = "kadamrahulk@gmail.com";
            try
            {
                IHttpActionResult tmpResult = objEmployeeController.PutEmployee(1, tmpEmployee);
            }
            catch(Exception ex)
            {
                Assert.Fail();
            }
            
        }

        [TestMethod()]
        public void PostEmployeeTest()
        {
            //To Do
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteEmployeeTest()
        {

            //To Do
            Assert.Fail();
        }
    }
}