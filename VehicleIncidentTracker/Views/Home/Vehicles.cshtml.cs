using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VehicleIncidentTracker.EntityFramework;

namespace VehicleIncidentTracker.Views.Home
{
    public class VehiclesModel : PageModel
    {
        public IList<Vehicle> Vehicles { get;set; }

    }
}
