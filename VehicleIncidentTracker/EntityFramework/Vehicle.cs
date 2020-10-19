using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VehicleIncidentTracker.EntityFramework
{
    public class Vehicle
    {
        [Key]
        public string VIN { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        [DisplayName("Year")]
        public string ModelYear { get; set; }

        public virtual ICollection<Incident> Incidents { get; set; }
    }
}
