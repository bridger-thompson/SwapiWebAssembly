using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAssemblyTest.Shared
{
    public class UserVehicle
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
