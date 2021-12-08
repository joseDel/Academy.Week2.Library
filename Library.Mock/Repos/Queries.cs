using Academy.Week2.Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week2.Library.Repos
{
    public class Queries
    {
        //query
        //Raggruppare i documenti per settore e specificare quanti documenti
        //ci sono per ogni settore.
        public static void MyQueries()
        {
            var list = InMemoryStorage.documents.GroupBy(d => d.Field).
                Select(x => new 
                {
            Categoria = x.Key,
            NumeroDocumenti = x.Count()});

            foreach (var item in list)
                Console.WriteLine(item.Categoria + " " + item.NumeroDocumenti);
        }
    }
}
