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

        [Get("/pbdispatchcoal/")]
        Task<CoalBauxiteModel> GetAllCoalMines();

        [Get("/pbdispatchbauxite/")]
        Task<CoalBauxiteModel> GetAllBauxiteMines();

        [Get("/minesbauxitecoaldata/coal")]
        Task<CoalBauxiteModel> GetDespatchQtyCoalMines();

        [Get("/minesbauxitecoaldata/bauxite")]
        Task<CoalBauxiteModel> GetDespatchQtyBauxiteMines();

    }

}
