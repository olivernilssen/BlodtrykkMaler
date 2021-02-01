using SQLite;
using System;

namespace BlodtrykkMaler.Models
{
    public class Measurement
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Systolic { get; set; }
        public int Diastolic { get; set; }
        public DateTime Date { get; set; }
        public string DateString { get; set; }
    }
}
