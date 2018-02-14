using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChartProject
{
    public class MinesDatabase
    {
        readonly SQLiteAsyncConnection database;

        public MinesDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<CoalBauxiteModel>().Wait();
        }

        public Task<List<CoalBauxiteModel>> GetItemsAsync()
        {
            return database.Table<CoalBauxiteModel>().ToListAsync();
        }

    }
}
