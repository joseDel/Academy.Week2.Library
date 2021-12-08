using Academy.Week2.Library.Entities;
using Library.Core.Entities;
using Library.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.BusinessLayer
{
    public class BusinessLayer : IBusinessLayer
    {
        private readonly IDocumentsRepository _docsRepository;
        private readonly IUsersRepository _userRepository;
        private readonly ILoansRepository _loanRepository;

        public BusinessLayer(IDocumentsRepository docsRepository, IUsersRepository userRepository, 
            ILoansRepository loanRepository)
        {
            _docsRepository = docsRepository;
            _userRepository = userRepository;
            _loanRepository = loanRepository;
        }

        public bool AddBook(Book book)
        {
            if(book == null)
                return false;
            return _docsRepository.Add(book);
        }

        public bool AddDVD(DVD dvd)
        {
            if (dvd == null)
                return false;
            return _docsRepository.Add(dvd);
        }

        public bool AddLoan(Loan loan)
        {
            return _loanRepository.Add(loan);
        }

        public bool AddUser(User user)
        {
            return _userRepository.Add(user);
        }

        public User? GetByEmail(string email)
        {
            if (email == null)
                return null;
            return _userRepository.GetByEmail(email);
        }

        public Loan GetLoanByBookId(int id)
        {
            if (id == null)
                return null;
            return _loanRepository.GetById(id);
        }

        public Document SearchDoc(int id)
        {
            if (id == null)
                return null;
            return _docsRepository.GetById(id);
        }

        public void Update(Object item)
        {
            if (item is Loan)
                _loanRepository.Update((Loan)item);
            if (item is Document)
                _docsRepository.Update((Document)item);
        }
    }
}
