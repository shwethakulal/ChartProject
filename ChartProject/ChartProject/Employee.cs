using System;
using System.Collections.Generic;
using System.Text;

namespace ChartProject
{
    public class Employee
    {
        public string ename { get; set; }
        public double salary { get; set; }

        public Employee(string ename, double salary)
        {
            this.ename = ename;
            this.salary = salary;
        }

        public Employee()
        {
        }
    }
}
