using Academy.Week2.Library.Entities;
using Library.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.ConsoleApp
{
    internal class AdminMenu : Menu
    {
        private readonly User _user;

        public AdminMenu(User user)
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
                Console.WriteLine("Scegli 1 per aggiungere un documento." +
                    "\nScegli 2 per effettuare un prestito." +
                    "\nScegli 3 per restituire un documento." +
                    "\nScegli 4 per cercare un documento." +
                    "\nScegli Q per uscire.");

                choice = Console.ReadKey().KeyChar;

                Console.WriteLine();

                switch (choice)
                {
                    case '1':
                        AddDocument();
                        break;
                    case '2':
                        DoLoan(_user);
                        break;
                    case '3':
                        GiveDocBack(_user);
                        break;
                    case '4':
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

        public void AddDocument()
        {
            Console.WriteLine("Scegli tipo di documento da aggiungere: ");
            char choice;
            do 
            { 
                Console.WriteLine("Scegli 1 per aggiungere un libro." +
                     "\nScegli 2 per aggiungere un DVD.");

                choice = Console.ReadKey().KeyChar;

                Console.WriteLine();
                switch (choice)
                {
                    case '1':
                        AddBook();
                        break;
                    case '2':
                        AddDVD();
                        break;
                    default:
                        Console.WriteLine("Scelta non valida");
                        break;
                }

            }
            while (choice != '1' || choice != '2');

            string title;
            string author;
            string publishingYear;
            string field;
            bool available;
            
        }

        public void AddDVD()
        {
            string title;
            string author;
            int publishingYear;
            string field;
            bool available;
            int duration;

            Console.WriteLine("Titolo: ");
            title = Console.ReadLine();

            Console.WriteLine("Autore: ");
            author = Console.ReadLine();

            Console.WriteLine("Anno di pubblicazione: ");
            while (!int.TryParse(Console.ReadLine(), out publishingYear))
            {
                Console.WriteLine("Inserisci un formato corretto!");
            }

            Console.WriteLine("Settore: ");
            field = Console.ReadLine();

            Console.WriteLine("Numero di pagine: ");
            while (!int.TryParse(Console.ReadLine(), out duration))
            {
                Console.WriteLine("Inserisci un formato corretto di data!");
            }

            DVD dvd = new DVD()
            {
                Title = title,
                Author = author,
                PublishingYear = publishingYear,
                Field = field,
                Available = true,
                Type = "dvd",
                Duration = duration
            };

            bool added = mainBL.AddDVD(dvd);
            if (added)
                Console.WriteLine("Il documento è stato aggiunto correttamente.");
            else Console.WriteLine("Qualcosa è andato storto.");
        }

        public void AddBook()
        {
            string title;
            string author;
            int publishingYear;
            string field;
            bool available;
            int numberPages;

            Console.WriteLine("Titolo: ");
            title = Console.ReadLine();

            Console.WriteLine("Autore: ");
            author = Console.ReadLine();

            Console.WriteLine("Anno di pubblicazione: ");
            while (!int.TryParse(Console.ReadLine(), out publishingYear))
            {
                Console.WriteLine("Inserisci un formato corretto!");
            }

            Console.WriteLine("Settore: ");
            field = Console.ReadLine();

            Console.WriteLine("Numero di pagine: ");
            while (!int.TryParse(Console.ReadLine(), out numberPages))
            {
                Console.WriteLine("Inserisci un formato corretto di data!");
            }

            Book book = new Book()
            {
                Title = title,
                Author = author,
                PublishingYear = publishingYear,
                Field = field,
                Available = true,
                Type = "book",
                NumberPages = numberPages
            };

            bool added = mainBL.AddBook(book);
            if (added)
                Console.WriteLine("Il documento è stato aggiunto correttamente.");
            else Console.WriteLine("Qualcosa è andato storto.");
        }
    }
}
