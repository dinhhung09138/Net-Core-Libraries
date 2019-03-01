using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.MySQL
{
    public class BookShelf
    {
        public int BookShelfId { get; set; }
        public string BookShelfName { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }

    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public decimal? Grade { get; set; }
        public DateTime PublishedDate { get; set; }
        public virtual BookShelf BookShelf { get; set; }
        public virtual ICollection<BookGenre> BookGenres { get; set; }
    }

    public class Genre
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public virtual ICollection<BookGenre> BookGenres { get; set; }
    }

    public class BookGenre
    {
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
    }

    public class LibraryDbContext : DbContext
    {
        // Tables
        public DbSet<BookShelf> BookShelf { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<BookGenre> BookGenre { get; set; }

        // Database configuration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(ConfigurationManager.ConnectionStrings["LibraryDbContext"].ConnectionString);
        }

        // Create data types, relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookShelf>(entity =>
            {
                entity.HasKey(e => e.BookShelfId);
                entity.Property(e => e.BookShelfName).HasMaxLength(50).IsRequired();
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.BookId);
                entity.Property(e => e.BookName).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Grade).HasColumnType("DECIMAL(2,1)").IsRequired(false);
                entity.Property(e => e.PublishedDate).HasColumnType("TIMESTAMP").HasDefaultValueSql("CURRENT_TIMESTAMP").IsRequired();
                entity.HasOne<BookShelf>(b => b.BookShelf).WithMany(bs => bs.Books);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(e => e.GenreId);
                entity.Property(e => e.GenreName).HasMaxLength(50).IsRequired(true);
            });

            modelBuilder.Entity<BookGenre>(entity =>
            {
                entity.HasKey(e => new { e.BookId, e.GenreId });
                entity.HasOne<Book>(bg => bg.Book).WithMany(b => b.BookGenres);
                entity.HasOne<Genre>(bg => bg.Genre).WithMany(g => g.BookGenres);
            });
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            InsertData();
            PrintData();
        }

        private static void InsertData()
        {
            using (var context = new LibraryDbContext())
            {
                // Creates the database if not exists
                context.Database.EnsureCreated();

                // --------- Add a bookshelf ----------
                var bookShelf = new BookShelf() {
                    BookShelfName = "A001"
                };
                context.BookShelf.Add(bookShelf);

                // ---------- Add some Books -----------
                // Book 1
                var book1 = new Book()
                {
                    BookName = "Book 1",
                    Grade = 6.7m,
                    BookShelf = bookShelf
                };
                context.Book.Add(book1);

                // Book 2
                var book2 = new Book()
                {
                    BookName = "Book 2",
                    Grade = 8.3m,
                    BookShelf = bookShelf
                };
                context.Book.Add(book2);

                // ---------- Add some Genres -----------
                // Genre 1
                var genre1 = new Genre()
                {
                    GenreName = "Genre 1"
                };
                context.Genre.Add(genre1);

                // Genre 2
                var genre2 = new Genre()
                {
                    GenreName = "Genre 2"
                };
                context.Genre.Add(genre2);

                // --------- Add some BookGenres ---------
                // Book 1
                context.BookGenre.Add(new BookGenre()
                {
                    Book = book1,
                    Genre = genre1
                });

                // Book 2
                context.BookGenre.Add(new BookGenre()
                {
                    Book = book2,
                    Genre = genre1
                });

                context.BookGenre.Add(new BookGenre()
                {
                    Book = book2,
                    Genre = genre2
                });

                // Saves changes
                context.SaveChanges();
            }
        }

        private static void PrintData()
        {
            using (var context = new LibraryDbContext())
            {
                var data = new StringBuilder();

                var bookList = context.Book.Include(b => b.BookShelf);

                foreach (var book in bookList)
                {
                    var genreList = context.BookGenre
                        .Where(bg => bg.BookId == book.BookId)
                        .Select(bg => bg.Genre.GenreName).ToList();

                    data.AppendLine($"BookId: {book.BookId}");
                    data.AppendLine($"BookName: {book.BookName}");
                    data.AppendLine($"Genre: { string.Join(", ", genreList) }");
                    data.AppendLine($"ShelfName: {book.BookShelf.BookShelfName}");
                    data.AppendLine();
                }
                
                Console.WriteLine(data.ToString());
                Console.ReadLine();
            }
        }
    }
}
