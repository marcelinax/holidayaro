﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Holidayaro.Models
{
    public class HotelDescription
    {
        public int HotelDescriptionId { get; set; }
        [ForeignKey("HotelId")]
        public int HotelId { get; set; }
     [Required]
        public string Name { get; set; }
    }
}
