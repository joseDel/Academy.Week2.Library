using Academy.Week2.Library.Repos;
using Library.Core.Entities;
using Library.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Mock.Repos
{
    public class MockLoansRepository : ILoansRepository
    {
        public bool Add(Loan item)
        {
            if (item == null)
                return false;

            item.Id = InMemoryStorage.loans.Max(b => b.Id) + 1;
            InMemoryStorage.loans.Add(item);
            return true;
        }

        public bool Delete(Loan item)
        {
            throw new NotImplementedException();
        }

        public List<Loan> FetchAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Loan> FetchAllFilter(Func<Loan, bool> filter = null)
        {
            throw new NotImplementedException();
        }

        public Loan GetById(int id)
        {
            return InMemoryStorage.loans.SingleOrDefault(b => b.DocId == id);
        }

        public bool Update(Loan item)
        {
            var toModifyLoan = GetById(item.Id);
            var index = InMemoryStorage.loans.IndexOf(toModifyLoan);
            if (index != -1)
            {
                InMemoryStorage.loans[index] = item; //nella lista, all'indice trovato, metto l'oggetto modificato
            }
            return false;
        }
    }
}
