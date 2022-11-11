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
        public List<UserStarship>? Starships { get; set; }
        public List<UserVehicle>? Vehicles { get; set; }
        public int ClickRate { get; set; } = 1;
        public double AutoclickRate { get; set; } = 0;
    }
}
