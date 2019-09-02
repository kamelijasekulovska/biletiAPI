using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiletiApp.API.Models
{
    public class Seat
    {
        public Guid Id { get; set; } 

        public int Number { get; set; }
        public int Row { get; set; }
        public Boolean Enabled { get; set; }  
        public Sector Sector { get; set; }
        public int SectorId { get; set; }


    }
}
