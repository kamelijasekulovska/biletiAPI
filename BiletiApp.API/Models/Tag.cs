using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiletiApp.API.Models
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Label { get; set; }
        public string Value { get; set; }
    }
}
