using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week2.Library.Entities
{
    public class Document
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublishingYear { get; set; }
        public string Field { get; set; }
        public bool Available { get; set; }
        public string Type { get; set; }
        public override string ToString()
        {
            return $"Il documento selezionato è: " +
                $"{Title}. Autore: {Author}.";
        }

    }
}
