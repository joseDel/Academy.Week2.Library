using Academy.Week2.Library.Entities;
using Library.Core.BusinessLayer;
using Library.Core.Entities;
using Library.Core.Interfaces;
using Library.Mock.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.ConsoleApp
{
    public class Menu
    {
        protected static readonly IBusinessLayer mainBL =
            new BusinessLayer(new MockDocumentsRepository(),
                new MockUsersRepository(), new MockLoansRepository());

        internal static void Start()
        {
            Console.WriteLine("Benvenuto!");
            char choice;

            do
            {
                Console.WriteLine("Scegli 1 per effettuare il login." +
                    "\nScegli 2 per registrarti al sistema." +
                    "\nScegli 3 per proseguire senza autenticazione." +
                    "\nScegli Q per uscire.");

                choice = Console.ReadKey().KeyChar;

                Console.WriteLine();

                switch (choice)
                {
                    case '1': 
                        Menu.Login();
                        break;
                    case '2':
                        Menu.Registration();
                        break;
                    case '3':
                        FreeUserMenu nonAdminMenu = new FreeUserMenu(null);
                        nonAdminMenu.Browse();
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

        private static void Registration()
        {
            int id;
            string name;
            string surname;
            string email;
            string password;
            string phoneNumber;
            bool admin = false;

            Console.WriteLine("Inserisci i tuoi dati per effettuare la registrazione.");

            Console.WriteLine("Nome: ");
            name = Console.ReadLine();

            Console.WriteLine("Cognome: ");
            surname = Console.ReadLine();

            Console.WriteLine("Email: ");
            email = Console.ReadLine();

            Console.WriteLine("Scegli password: ");
            password = Console.ReadLine();

            Console.WriteLine("Numero di telefono: ");
            phoneNumber = Console.ReadLine();

            User user = new User()
            {
                Name = name,
                Surname = surname,
                Email = email,
                Password = password,    
                PhoneNumber = phoneNumber,
                Admin = admin,
            };

            bool added = mainBL.AddUser(user);
            if (added)
                Console.WriteLine("Registrazione avvenuta correttamente.");
            else Console.WriteLine("Qualcosa è andato storto.");

            if (!user.Admin)
            {
                FreeUserMenu nonAdminMenu = new FreeUserMenu(user);
                nonAdminMenu.Browse();
            }
            else 
            {
                AdminMenu adminMenu = new AdminMenu(user);
                adminMenu.Browse(); 
            }
        }

        private static void Login()
        {
            string email = null;
            string password;
            User user = null;

            Console.WriteLine("Inserisci email: ");
            while (user == null)
            {
                email = Console.ReadLine();
                user = mainBL.GetByEmail(email);
                if (user == null)
                {
                    Console.WriteLine("Email non trovata. Inserisci mail corretta: ");
                    email = Console.ReadLine();
                }
            }

            Console.WriteLine("Inserisci password: ");
            password = Console.ReadLine();
            while (user.Password != password)
            {
                Console.WriteLine("Password errata. Inserisci password corretta: ");
                password = Console.ReadLine();
            }

            if (!user.Admin)
            {
                FreeUserMenu nonAdminMenu = new FreeUserMenu(user);
                nonAdminMenu.Browse();
            }
            else
            {
                AdminMenu adminMenu = new AdminMenu(user);
                adminMenu.Browse();
            }
        }

        protected void GiveDocBack(User user)
        {
            int id;
            Console.WriteLine("Digitare Id del documento da restituire: ");
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("L'id può essere composto solo da numeri. Riprova: ");
            }

            Loan loan = mainBL.GetLoanByBookId(id);
            if (loan == null)
                Console.WriteLine("Spiacenti, non risulta che il documento" +
                    " selezionato sia in prestito.");
            else if (loan.UserId != user.Id)
                Console.WriteLine("Il documento selezionato" +
                    " risulta in prestito a un altro utente.");
            else
            {
                loan.EndingDate = DateTime.Now;
                mainBL.Update(loan);
                Console.WriteLine("Il documento è stato restituito correttamente.");
            }
        }
        protected void DoLoan(User user)
        {
            Document document = SearchDoc();
            if (document != null)
            {
                if (!document.Available)
                    Console.WriteLine("Spiacenti, il documento selezionato è già" +
                        " in prestito.");
                else
                {
                    Loan loan = new Loan()
                    {
                        StartingDate = DateTime.Now,
                        EndingDate = null,
                        UserId = user.Id,
                        DocId = document.Id,
                    };
                    bool added = mainBL.AddLoan(loan);
                    if (added)
                    {
                        document.Available = false;
                        mainBL.Update(document);
                        Console.WriteLine("Prestito effettuato correttamente.");
                    }
                    else Console.WriteLine("Qualcosa è andato storto.");
                }
            }
        }
        protected Document SearchDoc()
        {
            int id;
            Console.WriteLine("Scrivi codice del documento: ");
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("L'id può essere composto solo da numeri. Riprova: ");
            }
            Document document = mainBL.SearchDoc(id);
            if (document == null)
                Console.WriteLine("Il documento selezionato non esiste.");
            else
            {
                Console.WriteLine(document);
            }

            return document;
        }
    }
}
