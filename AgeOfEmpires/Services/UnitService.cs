using AgeOfEmpires.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AgeOfEmpires.Services
{
    public class UnitService : IUnitService
    {
        /// <summary>
        /// This method returns the List of two random Units 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Unit>> GetUnits()
        {
            List<Unit> unit = null;
            int UnitId1, UnitId2;
            Random random = new Random();
            UnitId1 = random.Next(100);
            UnitId2 = random.Next(100);

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://age-of-empires-2-api.herokuapp.com/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    Task<HttpResponseMessage> response;
                    // HTTP Unit1 GET
                    response = client.GetAsync(string.Format("api/v1/unit/{0}", UnitId1));
                    unit = new List<Unit>();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        dynamic result = JObject.Parse(response.Result.Content.ReadAsStringAsync().Result);
                        unit.Add(new Unit { id = result.id, attack = result.attack, hit_points = result.hit_points, name = result.name });
                    }

                    // HTTP Unit2 GET
                    response = client.GetAsync(string.Format("api/v1/unit/{0}", UnitId2));
                    if (response.Result.IsSuccessStatusCode)
                    {
                        dynamic result = JObject.Parse(response.Result.Content.ReadAsStringAsync().Result);
                        unit.Add(new Unit { id = result.id, attack = result.attack, hit_points = result.hit_points, name = result.name });
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return unit;
        }
    }
}