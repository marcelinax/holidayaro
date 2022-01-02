using Holidayaro.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Holidayaro.Models
{

    public class Hotel
    {
        public int HotelId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Country { get; set; }
        public int Price { get; set; }
        
        public int Rating { get; set; }
        public int Days { get; set; }
        [Required]
        public string Room { get; set; }
      
        [Required]
        public string Board { get; set; }

        public ICollection<HotelAttraction> HotelAttractions { get; set; }
        public ICollection<HotelDescription> HotelDescriptions { get; set; }
        public ICollection<PhotosUrl> PhotosUrls { get; set; }
}
}
