using Microsoft.EntityFrameworkCore;
using WebAssemblyTest.Shared;

namespace WebAssemblyTest.Server.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder builder;

        public DbInitializer(ModelBuilder builder)
        {
            this.builder = builder;
        }

        public void Seed()
        {
            builder.Entity<Starship>().HasData(
                new Starship() { Id = 1, Cost_In_Credits = 50000, Name = "Test", Crew = "5", Hyperdrive_Rating = "3.0", Length = "12", Max_Atmosphering_Speed = "400", Model = "Test Model", Passengers = "5"}
            );
        }
    }
}
