using Holidayaro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Holidayaro.Repositories
{
    public interface IRepository<T>
    {
        T Find(int id);
        T Delete(int id);
        T Add(T payment);
        T Update(T payment);
        IList<T> FindAll();
        Boolean Exists(int id);
    }
}
