using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace TestDb.Models
{
    public class TheaterContext : DbContext
    {
        public TheaterContext(DbContextOptions<TheaterContext> options)
            : base(options)
        { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }

    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Movie need name.")]
        public string Title { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }

    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Customer need name.")]
        public string Name { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString ="{0: dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        public DateTime JoinDate { get; set; }

        public string Phone { get; set; }
    }
}