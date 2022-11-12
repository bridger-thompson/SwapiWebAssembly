using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAssemblyTest.Shared
{
    public class User
    {
        public string Id { get; set; }
        public Person? Person { get; set; }
        public long Credits { get; set; } = 0;
        public List<Starship>? Starships { get; set; } = new();
        public List<Vehicle>? Vehicles { get; set; } = new();
        public int ClickRate { get; set; } = 1;
        public double AutoclickRate { get; set; } = 0;
    }
}
