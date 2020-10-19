using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VehicleIncidentTracker.EntityFramework;

namespace VehicleIncidentTracker.Views.Home
{
    public class AddIncidentModel : PageModel
    {
        [BindProperty]
        public Incident Incident { get; set; }
    }
}
