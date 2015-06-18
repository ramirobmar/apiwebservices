using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetItem(int id);
        T Create(T item);
        bool Update(T item);
        bool Delete(int id);
        void Reset();
    }
}
