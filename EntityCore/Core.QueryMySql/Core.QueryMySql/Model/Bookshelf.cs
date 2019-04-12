using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QueryMySql.Model
{
    class BookShelf
    {
        public int BookShelfId { get; set; }
        public string BookShelfName { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
