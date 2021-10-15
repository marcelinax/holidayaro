using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Holidayaro.Models
{
    public class HotelAttraction
    {
        public int HotelAttractionId { get; set; }
        [ForeignKey("HotelId")]
        public int HotelId { get; set; }
        public string Name { get; set; }
    }
}
