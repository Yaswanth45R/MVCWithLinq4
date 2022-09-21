using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWithLinq3.Models
{
    public class EmployeeDAL
    {
        MVCDBDataContext dc = new MVCDBDataContext();
        public List<SelectListItem> GetDepartment()
        {
            List<SelectListItem> Depts = new List<SelectListItem>();
            foreach (var item in dc.Departments)
            {
                SelectListItem li = new SelectListItem { Text = item.Dname, Value = item.Did.ToString() };
                Depts.Add(li);
            }
            return Depts;
        }
        public List<EmpDepts> GetEmployees()
        {
            var Records = from E in dc.Employees join D in dc.Departments on E.Did equals D.Did where E.Status == true select new { E.Eid, E.Ename, E.Job, E.Salary, D.Did, D.Dname, D.Location };
            List<EmpDepts> Emps = new List<EmpDepts>();
            foreach (var Record in Records)
            {
                EmpDepts Emp = new EmpDepts { Eid = Record.Eid, Ename = Record.Ename, Job = Record.Job, Salary = Record.Salary, Did = Record.Did, Dname = Record.Dname, Location = Record.Location };
                Emps.Add(Emp);
            }
            return Emps;
        }
        public EmpDepts GetEmployee(int Eid)
        {
            var Record = (from E in dc.Employees join D in dc.Departments on E.Did equals D.Did where E.Status == true && E.Eid==Eid select new { E.Eid, E.Ename, E.Job, E.Salary, D.Did, D.Dname, D.Location }).Single();
            EmpDepts Emp = new EmpDepts { Eid=Record.Eid,Ename=Record.Ename, Job = Record.Job, Salary = Record.Salary, Did = Record.Did, Dname = Record.Dname, Location = Record.Location };
            return Emp;
        }
    }
}