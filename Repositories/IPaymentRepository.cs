using Holidayaro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Holidayaro.Repositories
{
    public interface IPaymentRepository : IRepository<Payment>
    {
        dynamic GetManyByPageSizeAndOffset(int pageSize, int startIndex = -1);
    }
}
