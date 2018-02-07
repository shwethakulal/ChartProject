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
                new Employee{ename="meena",salary=1500.00 },
                new Employee{ename="harshi",salary=500.00 },
                new Employee{ename="pooja",salary=6500.00 },
                 new Employee{ename="achu",salary=3500.00 },
                  new Employee{ename="kempa",salary=1500.00 },
                   new Employee{ename="damu",salary=11500.00 }
            };
        }
    }
}
