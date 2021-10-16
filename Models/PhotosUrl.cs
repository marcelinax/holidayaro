using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Holidayaro.Models
{
    public class PhotosUrl
    {
        public int PhotosUrlId { get; set; }

        public int HotelId { get; set; }
        [ForeignKey("HotelId")]
        public Hotel Hotel { get; set; }

        public string PhotoUrl { get; set; }
    }
}
