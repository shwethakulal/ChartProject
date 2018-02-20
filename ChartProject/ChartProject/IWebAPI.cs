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

        //[Get("/minesbauxitecoaldata/coal/currentdate")]
        [Get("/minesbauxitecoaldata/allcoal")]
        Task<List<CoalDateWiseModel>> GetCoalDateMines([AliasAs("year")] int year, [AliasAs("month")] int month, [AliasAs("day")] int day);

        [Get("/minesbauxitecoaldata/allbauxite")]
        Task<List<CoalDateWiseModel>> GetBauxiteDateMines([AliasAs("year")] int year, [AliasAs("month")] int month, [AliasAs("day")] int day);

        [Get("/minesbauxitecoaldata/bauxite")]
        Task<CoalBauxiteModel> GetDespatchQtyBauxiteMines();
        
    }

}
