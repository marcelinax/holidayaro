using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Holidayaro.Models;

namespace Holidayaro.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Holidayaro.Models.HotelAttraction> HotelAttraction { get; set; }
        public DbSet<Holidayaro.Models.HotelDescription> HotelDescription { get; set; }
        public DbSet<Holidayaro.Models.Hotel> Hotel { get; set; }
        public DbSet<Holidayaro.Models.PhotosUrl> PhotosUrl { get; set; }
        public DbSet<Holidayaro.Models.Reservation> Reservation { get; set; }
    }
}
