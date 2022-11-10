using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web.Resource;
using WebAssemblyTest.Server.Data;
using WebAssemblyTest.Shared;

namespace WebAssemblyTest.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAdB2C:Scopes")]
    public class SwapiController : ControllerBase
    {
        private readonly ILogger<SwapiController> logger;
        private readonly SwapiDbContext context;
        private readonly HttpClient client;

        public SwapiController(ILogger<SwapiController> logger, SwapiDbContext context, HttpClient client)
        {
            this.logger = logger;
            this.context = context;
            this.client = client;
        }

        [HttpGet("person/{page}")]
        public async Task<Person> GetPerson(int page)
        {
            try
            {
                return await client.GetFromJsonAsync<Person>($"https://swapi.dev/api/people/{page}/");
            }
            catch
            {
                return new Person();
            }
        }

        [HttpGet("starships")]
        public async Task<IEnumerable<Starship>> GetStarships()
        {
            var starships = await context.Starship.ToListAsync();
            return starships.OrderBy(s => s.Cost_In_Credits);
        }

        [HttpGet("vehicles")]
        public async Task<IEnumerable<Vehicle>> GetVehicles()
        {
            var vehicles = await context.Vehicle.ToListAsync();
            return vehicles.OrderBy(v => v.Cost_In_Credits);
        }

        public async Task<Starship> GetStarship(int page)
        {
            try
            {
                return await client.GetFromJsonAsync<Starship>($"https://swapi.dev/api/starships/{page}/");
            }
            catch
            {
                return new Starship();
            }
        }

        public async Task<Vehicle> GetVehicle(int page)
        {
            try
            {
                return await client.GetFromJsonAsync<Vehicle>($"https://swapi.dev/api/vehicles/{page}/");
            }
            catch
            {
                return new Vehicle();
            }
        }

        [HttpGet("populate")]
        public async Task PopulateDatabase()
        {
            for (int i = 0; i < 50; i++)
            {
                try
                {
                    Person person = await GetPerson(i);
                    var existingPerson = context.Person.FirstOrDefault(p => p.Name == person.Name);
                    if (existingPerson == null && person.Name != "" && person.Name != null)
                    {
                        await context.Person.AddAsync(person);
                    }

                    Starship starship = await GetStarship(i);
                    var existingShip = context.Starship.FirstOrDefault(s => s.Name == starship.Name);
                    if (existingShip == null && starship.Name != "" && starship.Name != null)
                    {
                        await context.Starship.AddAsync(starship);
                    }

                    Vehicle vehicle = await GetVehicle(i);
                    var existingVehicle = context.Vehicle.FirstOrDefault(p => p.Name == vehicle.Name);
                    if (existingVehicle == null && vehicle.Name != "" && vehicle.Name != null)
                    {
                        await context.Vehicle.AddAsync(vehicle);
                    }
                }
                catch
                {
                    logger.LogError("No object at index " + i);
                }

            }
            await context.SaveChangesAsync();
        }
    }
}
