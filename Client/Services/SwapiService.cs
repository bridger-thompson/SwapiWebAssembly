using WebAssemblyTest.Shared;

namespace WebAssemblyTest.Client.Services
{
    public class SwapiService
    {
        private readonly IConfiguration config;
        private readonly HttpClient client;
        private readonly ILogger<SwapiService> logger;

        public SwapiService(IConfiguration config, HttpClient client, ILogger<SwapiService> logger)
        {
            this.config = config;
            this.client = client;
            this.logger = logger;

        }

        //public async Task<Person> GetPersonFromApi(int page)
        //{
        //    try
        //    {
        //        return await client.GetFromJsonAsync<Person>($"api/Swapi/person/{page}");
        //    }
        //    catch
        //    {
        //        return new Person();
        //    }
        //}
    }
}
