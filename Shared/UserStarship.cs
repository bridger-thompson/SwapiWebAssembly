using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAssemblyTest.Shared
{
    public class UserStarship
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Starship Starship { get; set; }
    }
}
