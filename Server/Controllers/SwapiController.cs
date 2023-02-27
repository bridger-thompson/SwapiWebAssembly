using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web.Resource;
using WebAssemblyTest.Server.Data;
using WebAssemblyTest.Shared;

namespace WebAssemblyTest.Server.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    //[RequiredScope(RequiredScopesConfigurationKey = "AzureAdB2C:Scopes")]
    public class SwapiController : ControllerBase
    {
        private readonly ILogger<SwapiController> logger;
        private readonly SwapiDbContext context;
        private readonly HttpClient client;
        private readonly testPostgres testContext;

        public SwapiController(ILogger<SwapiController> logger, SwapiDbContext context, HttpClient client, testPostgres testContext)
        {
            this.logger = logger;
            this.context = context;
            this.client = client;
            this.testContext = testContext;
        }

        [HttpGet("test")]
        public async Task<Test> GetTestThing()
        {
            return await testContext.Tests.FirstOrDefaultAsync(a => a.Name == "test");
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

        [HttpPost("addUser/{id}")]
        public async Task AddUser(string id)
        {
            var existingUser = await context.User.FirstOrDefaultAsync(u => u.Id == id);
            if (existingUser == null)
            {
                User user = new User
                {
                    Id = id,
                };
                await context.User.AddAsync(user);
                await context.SaveChangesAsync();
            }
        }

        [HttpGet("user/{id}")]
        public async Task<User> GetUser(string id)
        {
            return await context.User.Include(u => u.Vehicles)
                .ThenInclude(v => v.Vehicle)
                .Include(u => u.Starships)
                .ThenInclude(s => s.Starship)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        [HttpGet("vehicle/{id}/{name}")]
        public async Task PurchaseVehicle(int id, string name)
        {
            Vehicle vehicle = await context.Vehicle.FirstOrDefaultAsync(v => v.Id == id);
            User user = await context.User.FirstOrDefaultAsync(u => u.Id == name);
            UserVehicle uv = new UserVehicle
            {
                Vehicle = vehicle,
                User = user,
            };
            await context.UserVehicle.AddAsync(uv);
            user.Credits -= vehicle.Cost_In_Credits;
            await context.SaveChangesAsync();
        }

        [HttpGet("starship/{id}/{name}")]
        public async Task PurchaseStarship(int id, string name)
        {
            Starship starship = await context.Starship.FirstOrDefaultAsync(s => s.Id == id);
            User user = await context.User.FirstOrDefaultAsync(u => u.Id == name);
            UserStarship us = new UserStarship
            {
                Starship = starship,
                User = user,
            };
            await context.UserStarship.AddAsync(us);
            user.Credits -= starship.Cost_In_Credits;
            await context.SaveChangesAsync();
        }

        [HttpGet("usercredits/{id}/{amount}")]
        public async Task UpdateCredits(string id, int amount)
        {
            User user = await context.User.FirstOrDefaultAsync(u => u.Id==id);
            user.Credits += amount;
            await context.SaveChangesAsync();
        }

        [HttpGet("userrate/{id}/{credits}")]
        public async Task DoubleRate(string id, int credits)
        {
            User user = await context.User.FirstOrDefaultAsync(u => u.Id == id);
            user.ClickRate *= 2;
            user.Credits = credits;
            await context.SaveChangesAsync();
        }
    }
}
