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
        public void Employee_Insert(EmpDepts obj)
        {
            Employee Emp = new Employee { Ename=obj.Ename, Job=obj.Job, Salary=obj.Salary,Did=obj.Did,Status=true };

            dc.Employees.InsertOnSubmit(Emp);
            dc.SubmitChanges();
        }
        public void Employee_Update(EmpDepts NewValues)
        {
            Employee OldValues = dc.Employees.Single(E=>E.Eid==NewValues.Eid);
            OldValues.Ename = NewValues.Ename; 
            OldValues.Salary = NewValues.Salary;
            OldValues.Job = NewValues.Job;
            OldValues.Did = NewValues.Did;
            dc.SubmitChanges();
        }
        public void Employee_Delete(int Eid)
        {
            Employee OldValues = dc.Employees.Single(E => E.Eid == Eid);
            OldValues.Status = false;
            dc.SubmitChanges();
        }
    }
}