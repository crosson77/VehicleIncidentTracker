using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using VehicleIncidentTracker.Models;
using VehicleIncidentTracker.EntityFramework;

namespace VehicleIncidentTracker
{
    public class Helper
    {
        /// <summary>
        /// Get vehicle details from the VIN decode api
        /// </summary>
        /// <param name="vin"></param>
        /// <returns></returns>
        internal static Vehicle GetVehicleByVIN(string vin)
        {
            string url = $"https://vpic.nhtsa.dot.gov/api/vehicles/DecodeVinValues/{vin}?format=json";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                var tmp = client.GetAsync(url).Result;
                if (tmp.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<VinResult>(tmp.Content.ReadAsStringAsync().Result).Results[0];
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
