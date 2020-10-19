using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleIncidentTracker.EntityFramework
{
    public class Incident
    {
        [Key]
        public int IncidentID { get; set; }

        [DisplayName("Date")]
        public DateTime DateAndTime { get; set; }

        public string Note { get; set; }

        public string VIN { get; set; }

        [ForeignKey("VIN")]
        public virtual Vehicle Vehicle { get; set; }

        public bool IsValid()
        {
            return !String.IsNullOrWhiteSpace(Note) && !String.IsNullOrWhiteSpace(VIN) && DateAndTime > DateTime.MinValue;
        }
    }
}
