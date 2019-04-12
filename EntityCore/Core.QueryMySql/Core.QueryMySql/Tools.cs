using Core.QueryMySql.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QueryMySql
{
    class Tools
    {
        public static string GetConnectionString(String name = "LibraryDb")
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public class LibraryDbContext : DbContext
        {
            public DbSet<BookShelf> BookShelf { get; set; }
            public DbSet<Model.Book> Book { get; set; }
            public DbSet<Genre> Genre { get; set; }
            public DbSet<BookGenre> BookGenre { get; set; }
            
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseMySQL(ConfigurationManager.ConnectionStrings["LibraryDb"].ConnectionString);
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<BookShelf>(entity =>
                {
                    entity.HasKey(e => e.BookShelfId);
                    entity.Property(e => e.BookShelfName).HasMaxLength(50).IsRequired();
                });

                modelBuilder.Entity<Model.Book>((Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Model.Book> entity) =>
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

                modelBuilder.Entity<BookGenre>((Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<BookGenre> entity) =>
                {
                    entity.HasKey(e => (new { e.BookId, e.GenreId }));
                    entity.HasOne<Model.Book>(bg => bg.Book).WithMany(b => b.BookGenres);
                    entity.HasOne<Genre>(bg => bg.Genre).WithMany(g => g.BookGenres);
                });
            }
        }

    }
}
