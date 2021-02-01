using BlodtrykkMaler.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlodtrykkMaler.Database
{
    public class MeasurmentsDb
    {
        readonly SQLiteAsyncConnection _database;
        public MeasurmentsDb(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Measurement>().Wait();
        }

        public Task<List<Measurement>> GetMeasurementsAsync()
        {
            return _database.Table<Measurement>().ToListAsync();
        }

        public Task<int> SaveMeasurmentAsync(Measurement measurement)
        {
            return _database.InsertAsync(measurement);
        }

        public Task<int> DeleteMeasurementAsync(Measurement measurement)
        {
            return _database.DeleteAsync(measurement);
        }

    }
}
