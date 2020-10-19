using System;

namespace VehicleIncidentTracker.Models
{
    public class IncidentFilter
    {
        public string VIN { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }
    }
}
