using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QueryMySql.Model
{
    class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public decimal? Grade { get; set; }
        public DateTime PublishedDate { get; set; }
        public int BookShelfId { get; set; }
        [System.ComponentModel.Browsable(false)]
        public virtual BookShelf BookShelf { get; set; }
        [System.ComponentModel.Browsable(false)]
        public virtual ICollection<BookGenre> BookGenres { get; set; }
    }
}
