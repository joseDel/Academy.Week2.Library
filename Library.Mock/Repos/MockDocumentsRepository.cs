using Academy.Week2.Library.Repos;
using Library.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Library.Mock.Repos
{
    public class MockDocumentsRepository : IDocumentsRepository
    {
        public bool Add(Academy.Week2.Library.Entities.Document item)
        {
            if (item == null)
                return false;

            item.Id = InMemoryStorage.documents.Max(b => b.Id) + 1;
            InMemoryStorage.documents.Add(item);
            return true;
        }

        public bool Delete(Academy.Week2.Library.Entities.Document item)
        {
            throw new NotImplementedException();
        }

        public List<Academy.Week2.Library.Entities.Document> FetchAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Academy.Week2.Library.Entities.Document> 
            FetchAllFilter(Func<Academy.Week2.Library.Entities.Document, bool> filter = null)
        {
            throw new NotImplementedException();
        }

        public Academy.Week2.Library.Entities.Document GetById(int id)
        {
            return InMemoryStorage.documents.SingleOrDefault(b => b.Id == id);
        }

        public bool Update(Academy.Week2.Library.Entities.Document item)
        {
            var toModifyDoc = GetById(item.Id);
            var index = InMemoryStorage.documents.IndexOf(toModifyDoc);
            if (index != -1)
            {
                InMemoryStorage.documents[index] = item; //nella lista, all'indice trovato, metto l'oggetto modificato
            }
            return false;
        }
    }
}
