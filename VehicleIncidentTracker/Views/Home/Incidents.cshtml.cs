using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VehicleIncidentTracker.EntityFramework;
using VehicleIncidentTracker.Models;

namespace VehicleIncidentTracker.Views.Home
{
    public class IncidentsModel : PageModel
    {
        public IList<Incident> Incidents { get;set; }

        public IncidentFilter Filter { get; set; }
    }
}
