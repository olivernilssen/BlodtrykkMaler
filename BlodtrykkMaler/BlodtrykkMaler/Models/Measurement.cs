using SQLite;
using System;

namespace BlodtrykkMaler.Models
{
    public class Measurement
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Systolic { get; set; }
        public string Diastolic { get; set; }
        public DateTime Date { get; set; }
        public string DateString { get; set; }
    }
}
