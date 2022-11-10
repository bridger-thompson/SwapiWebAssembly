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
        public Person Person { get; set; }
        public IEnumerable<Starship> Starships { get; set; }
        public IEnumerable<Vehicle> Vehicles { get; set; }
        public int ClickRate { get; set; }
        public double AutoclickRate { get; set; }
    }
}
