using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChartProject
{
    public interface IWebAPI
    {
        [Get("/employees/")]
        Task<List<Employee>> GetAllEmployees();
    }
}
