using System.Net.Http.Json;
using System.Text;
using WebAssemblyTest.Shared;

namespace WebAssemblyTest.Client.Services
{
    public class SwapiService
    {
        private readonly HttpClient client;
        private readonly ILogger<SwapiService> logger;

        public SwapiService(HttpClient client, ILogger<SwapiService> logger)
        {
            this.client = client;
            this.logger = logger;

        }

        public async Task<string> GetTestThing()
        {
            var testThing = await client.GetFromJsonAsync<Test>("api/Swapi/test");
            return testThing.Name;
        }

        public async Task<IEnumerable<Starship>> GetStarshipsFromApi()
        {
            return await client.GetFromJsonAsync<IEnumerable<Starship>>("api/Swapi/starships");
        }

        public async Task<IEnumerable<Vehicle>> GetVehiclesFromApi()
        {
            return await client.GetFromJsonAsync<IEnumerable<Vehicle>>("api/Swapi/vehicles");
        }

        public async Task<User> GetUserFromApi(string id)
        {
            return await client.GetFromJsonAsync<User>($"api/Swapi/user/{id}");
        }

        public async Task PurchaseVehicle(int id, string name)
        {
            await client.GetAsync($"api/Swapi/vehicle/{id}/{name}");
        }

        public async Task PurchaseStarship(int id, string name)
        {
            await client.GetAsync($"api/Swapi/starship/{id}/{name}");
        }

        public async Task UpdateCredits(string id, int amount)
        {
            await client.GetAsync($"api/Swapi/usercredits/{id}/{amount}");
        }

        public async Task UpdateClickRate(string id, long credits)
        {
            await client.GetAsync($"api/Swapi/userrate/{id}/{credits}");
        }
    }
}
