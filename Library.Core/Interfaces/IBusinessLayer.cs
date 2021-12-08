using Academy.Week2.Library.Entities;
using Library.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Interfaces
{
    public interface IBusinessLayer
    {
        bool AddUser(User user);
        User? GetByEmail(string email);
        bool AddDVD(DVD dvd);
        bool AddBook(Book book);
        Document SearchDoc(int id);
        bool AddLoan(Loan loan);
        Loan GetLoanByBookId(int id);
        void Update(Object item);
    }
}
