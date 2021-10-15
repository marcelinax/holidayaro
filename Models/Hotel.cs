using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Holidayaro.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Price { get; set; }
        public string PhotoUrl { get; set; }
        public double Rating { get; set; }
        public int Days { get; set; }
        public string Room { get; set; }
        public string Board { get; set; }
       
        public List<HotelAttraction> Attractions { get; set; }
}
}
