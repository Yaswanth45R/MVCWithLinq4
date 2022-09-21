using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace MVCWithLinq3.Models
{
    public class EmpDepts
    {
        public int Eid { get; set; }    
        public string Ename { get; set; }
        public string Job { get; set; }
        public decimal? Salary { get; set; }
        public int Did { get; set; }    
        public string Dname { get; set; }   
        public string Location { get; set; }
        public List<SelectListItem> Departments { get; set; }   
    }
}