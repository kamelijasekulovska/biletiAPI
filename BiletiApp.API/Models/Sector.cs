using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiletiApp.API.Models
{
    public class Sector
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public Boolean Seated { get; set; }
        public int Capacity { get; set; }
        public int Rows { get; set; }
        public ICollection<Seat> Seats { get; set; }
    }
}
