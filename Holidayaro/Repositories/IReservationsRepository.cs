using Holidayaro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Holidayaro.Repositories
{
    public interface IReservationsRepository : IRepository<Reservation>
    {
        List<Reservation> GetReservationsByToken(string token);
        List<Boolean> GetStatuesByToken(string token, List<Reservation> reservations);
    }
}
