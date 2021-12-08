using Academy.Week2.Library.Entities;
using Library.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week2.Library.Repos
{
    public class InMemoryStorage
    {
        // Liste
        public static List<User> users = new List<User>()
        {
            new User() { Name = "Franco", Surname = "Puddu", Id = 1, Email = "fpuddu@gmail.com",
            PhoneNumber = "0700000", Password = "1234", Admin = true },

            new User() { Name = "Pina", Surname = "Scamacca", Id = 2, Email = "pscam@gmail.com",
            PhoneNumber = "0724367", Password = "1234", Admin = false },

            new User() { Name = "Gianna", Surname = "Pirlo", Id = 3, Email = "gianna@gmail.com",
            PhoneNumber = "07084935", Password = "1234", Admin = true },

            new User() { Name = "Mario", Surname = "Brega", Id = 4, Email = "brega@gmail.com",
            PhoneNumber = "0707588352", Password = "1234", Admin = false },

            new User() { Name = "Salvo", Surname = "Galliani", Id = 1, Email = "galliani@gmail.com",
            PhoneNumber = "070768452", Password = "1234", Admin = true },
        };

        public static List<Document> documents = new List<Document>()
        {
            new Book() { Title = "Il Signore delle Mosche", Id = 0, Author = "Golding",
            Available = true, Field = "Novel", NumberPages = 600, PublishingYear = 1954,
            Type = "book"},

            new DVD() { Title = "Il Padrino", Id = 1, Author = "F.F. Coppola",
            Available = false, Field = "Drama", Duration = 0, PublishingYear = 1970,
            Type = "DVD"},

            new Book() { Title = "Metamorfosi", Id = 2, Author = "Kafka",
            Available = true, Field = "Drama", NumberPages = 80, PublishingYear = 1910,
            Type = "book"},
        };

        public static List<Loan> loans = new List<Loan>()
        {
            new Loan() {Id = 1, StartingDate = new DateTime(2021,12,1), 
            EndingDate = null, UserId = 1, DocId = 1}
        };
    }
}
