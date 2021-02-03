using BlodtrykkMaler.Models;
using SQLite;
using System;
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

        /// <summary>
        /// Call to database to fetch all measurements (based on id)
        /// </summary>
        /// <returns></returns>
        public async Task<List<Measurement>> GetMeasurementsAsync()
        {
            List<Measurement> list;

            try
            {
                list = await _database.Table<Measurement>().ToListAsync();
            }
            catch (SQLiteException)
            {
                throw new ArgumentNullException ("Measurments was not loaded from database");
            }


            return list;
        }

        /// <summary>
        /// Call to database to fetch all measurements ordered by date
        /// </summary>
        /// <returns></returns>
        public async Task<List<Measurement>> GetMeasurementsByDateAsync()
        {
            List<Measurement> list;

            try
            {
                list = await _database.Table<Measurement>().OrderBy(x => x.Date).ToListAsync();
            }
            catch (SQLiteException)
            {
                throw new ArgumentNullException("Measurments was not loaded from database");
            }


            return list;
        }

        /// <summary>
        /// Fetch a specific Measurement based on it's ID from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Measurement> GetMeasurementAsync(int id)
        {
            Measurement dbItem;
            try
            {
                dbItem = await _database.Table<Measurement>().Where(i => i.Id == id).FirstOrDefaultAsync();
            }
            catch (SQLiteException)
            {
                throw new Exception("Measurement with id: " + id + " does not exist in database");
            }

            return dbItem;
        }

        /// <summary>
        /// Save a new item (Measurement) to the database table
        /// </summary>
        /// <param name="measurement"></param>
        /// <returns></returns>

        public async Task<int> SaveMeasurmentAsync(Measurement measurement)
        {
            int newItemId;
            try
            {
                newItemId = await _database.InsertAsync(measurement);
            }
            catch (SQLiteException)
            {
                throw new Exception("The measurment was not added to the database");
            }

            return newItemId;
        }

        /// <summary>
        /// Delete an entry from the database table based on the entry ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteMeasurementAsync(int id)
        {
            int wasDeleted;
            try
            {
                wasDeleted = await _database.DeleteAsync<Measurement>(id);
            }
            catch (SQLiteException)
            {
                throw new Exception("The measurment with id: " + id + " was not deleted");
            }

            return wasDeleted;
        }

    }
}
