using Holidayaro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Holidayaro.Repositories
{
    public interface IRepository<T>
    {
        T FindOneById(int id);
        T DeleteOneById(int id);
        T AddNew(T item);
        T UpdateOne(T item);
        IList<T> FindAll();
        Boolean CheckIfExistsById(int id);
    }
}
