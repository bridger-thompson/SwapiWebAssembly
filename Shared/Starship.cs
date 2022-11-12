using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAssemblyTest.Shared
{
    public class Starship
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
		public string Name { get; set; }
		public string Model { get; set; }
		public long Cost_In_Credits { get; set; }
		public string Length { get; set; }
		public string Max_Atmosphering_Speed { get; set; }
		public string Crew { get; set; }
		public string Passengers { get; set; }
		public string Hyperdrive_Rating { get; set; }
	}
}
