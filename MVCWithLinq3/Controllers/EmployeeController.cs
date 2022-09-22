using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCWithLinq3.Models;

namespace MVCWithLinq3.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDAL obj = new EmployeeDAL();
        public ViewResult DisplayEmployees()
        {
            return View(obj.GetEmployees());
        }
        public ViewResult DisplayEmployee(int Eid)
        {
            return View(obj.GetEmployee(Eid));  
        }
        [HttpGet]
        public ViewResult AddEmployee()
        {
            EmpDepts Emp = new EmpDepts();
            Emp.Departments = obj.GetDepartment();
            return View(Emp);   
        }
        [HttpPost]
        public RedirectToRouteResult AddEmployee(EmpDepts Emp)
        {
            obj.Employee_Insert(Emp);
            return RedirectToAction("DisplayEmployees");
        }
        public ViewResult EditEmployee(int Eid)
        {
            EmpDepts Emp = obj.GetEmployee(Eid);
            Emp.Departments = obj.GetDepartment();
            return View(Emp);
        }
        public RedirectToRouteResult UpdateEmployee(EmpDepts Emp)
        {
            obj.Employee_Update(Emp);
            return RedirectToAction("DisplayEmployees");
        }
        public RedirectToRouteResult DeleteEmployees(int Eid)
        {
            obj.Employee_Delete(Eid);
            return RedirectToAction("DisplayEmployees");
        }
    }
}