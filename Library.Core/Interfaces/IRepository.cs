using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> FetchAllFilter(Func<T, bool> filter = null); // altro metodo che fa la fetch ma con filtro
        List<T> FetchAll();
        T GetById(int id);
        bool Add(T item);
        bool Update(T item);
        bool Delete(T item);
    }
}
