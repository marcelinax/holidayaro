using Holidayaro.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Holidayaro.Models
{

    public class HotelAttraction
    {
        public int HotelAttractionId { get; set; }
     
        public int HotelId { get; set; }
        [ForeignKey("HotelId")]
        public Hotel Hotel { get; set; }

        public string Name { get; set; }
    }
}
