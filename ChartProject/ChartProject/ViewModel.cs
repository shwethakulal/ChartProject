using System;
using System.Collections.Generic;
using System.Text;

namespace ChartProject
{
    public class ViewModel
    {
        public List<Employee> Data { get; set; }

        public ViewModel()
        {
            Data = new List<Employee>()
            {
                new Employee{ename="shwetha",salary=2500.00 },
                new Employee{ename="meena",salary=1500.00 }
            };
        }
    }
}
