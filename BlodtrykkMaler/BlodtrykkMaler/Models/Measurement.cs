using SQLite;
using System;

namespace BlodtrykkMaler.Models
{
    /// <summary>
    /// This is a model class that models our Measurements
    /// </summary>
    public class Measurement
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Systolic { get; set; }
        public int Diastolic { get; set; }
        public DateTime Date { get; set; }
        public string DateString { get; set; }

        /// <summary>
        /// Empty constructor for Measurement
        /// </summary>
        public Measurement() { }

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="systolic"></param>
        /// <param name="diastolic"></param>
        /// <param name="date"></param>
        public Measurement(int systolic, int diastolic, DateTime date)
        {
            this.Systolic = systolic;
            this.Diastolic = diastolic;
            this.Date = date;
            this.DateString = date.ToString("dd/MM/yy");
        }
    }
}
