using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using VehicleIncidentTracker.Models;
using VehicleIncidentTracker.EntityFramework;
using VehicleIncidentTracker.Views.Home;

namespace VehicleIncidentTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context _context;

        public HomeController(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Home page
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Vehicles page
        /// </summary>
        /// <returns>Page with list of vehicles in incidents</returns>
        public IActionResult Vehicles()
        {
            VehiclesModel model = new VehiclesModel();
            model.Vehicles = _context.Vehicles.ToList();
            return View(model);
        }

        /// <summary>
        /// List of incidents filtered by optional search paramters
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [Route("incidents")]
        public IActionResult Incidents(IncidentFilter filter)
        {
            IncidentsModel model = new IncidentsModel();
            model.Filter = filter;
            model.Incidents = _context.Incidents
                .Where(x => (String.IsNullOrWhiteSpace(filter.VIN) || x.Vehicle.VIN.StartsWith(filter.VIN.ToUpper())) && 
                x.DateAndTime >= (filter.FromDate.HasValue ? filter.FromDate : DateTime.MinValue) && 
                x.DateAndTime <= (filter.ToDate.HasValue ? filter.ToDate : DateTime.MaxValue))
                .Include(i => i.Vehicle).ToList();
            return View(model);
        }

        /// <summary>
        /// Show the page for adding an incident
        /// </summary>
        /// <returns></returns>
        [Route("incidents/add")]
        [HttpGet]
        public IActionResult AddIncident()
        {
            AddIncidentModel model = new AddIncidentModel();
            return View(model);
        }

        /// <summary>
        /// Post route for adding a new incident
        /// </summary>
        /// <param name="incident"></param>
        /// <returns></returns>
        [Route("incidents/add")]
        [HttpPost]
        public IActionResult PostIncident(Incident incident)
        {

            incident.VIN = incident.VIN.ToUpper();
            // Check if vin is already in db, if not get vehicle details and add it
            if (_context.Vehicles.FirstOrDefault(x => x.VIN == incident.VIN) == null)
            {
                Vehicle vehicle = Helper.GetVehicleByVIN(incident.VIN.ToUpper());
                if (String.IsNullOrWhiteSpace(vehicle.Make) || String.IsNullOrWhiteSpace(vehicle.Model) || String.IsNullOrWhiteSpace(vehicle.ModelYear))
                {
                    ModelState.AddModelError("VinDecode", "Unable to validate VIN and retrieve vehicle information. Please make sure the VIN is correct.");
                    return View("AddIncident");
                }
                else
                {
                    _context.Vehicles.Add(vehicle);
                }
            }
            _context.Incidents.Add(incident);
            _context.SaveChanges();

            return RedirectToAction("incidents");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
