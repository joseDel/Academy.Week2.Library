using Academy.Week2.Library.Entities;
using Library.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.ConsoleApp
{
    public class FreeUserMenu : Menu
    {
        private readonly User _user;

        public FreeUserMenu(User user)
        {
            _user = user;
        }

        public void Browse()
        {
            if (_user != null)
                Console.WriteLine($"Benvenuto {_user.Name} {_user.Surname}!");
            else
                Console.WriteLine($"Benvenuto!");
            char choice;

            do
            {
                Console.WriteLine("\nScegli 1 per effettuare un prestito." +
                    "\nScegli 2 per restituire un documento." +
                    "\nScegli 3 per cercare un documento." +
                    "\nScegli Q per uscire.");

                choice = Console.ReadKey().KeyChar;

                Console.WriteLine();

                switch (choice)
                {
                    case '1':
                        DoLoan(_user);
                        break;
                    case '2':
                        GiveDocBack(_user);
                        break;
                    case '3':
                        SearchDoc();
                        break;
                    case 'Q':
                        Console.WriteLine("Arrivederci");
                        break;
                    default:
                        Console.WriteLine("Scelta non valida");
                        break;
                }

            } while (choice != 'Q');
        }
    }
}
