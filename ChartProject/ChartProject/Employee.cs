using System;
using System.Collections.Generic;
using System.Text;

namespace ChartProject
{
    public class Employee
    {
        public string empno { get; set; }
        public string ename { get; set; }
        public string designation { get; set; }
        public long salary { get; set; }

       

        public Employee()
        {
        }

        public Employee(string empno, string ename, string designation, long salary)
        {
            this.empno = empno;
            this.ename = ename;
            this.designation = designation;
            this.salary = salary;
        }
    }
}
