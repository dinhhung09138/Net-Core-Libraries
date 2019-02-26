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
        [Column("MovieId")]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Movie need name.")]
        [Column("Title")]
        public string Title { get; set; }

        public int CustomerRefId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }

    public class Customer
    {
        [Key]
        [Column("CustomerId")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Customer need name.")]
        [DataType(DataType.Text)]
        [Column("Name")]
        public string Name { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString ="{0: dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        [Column("JoinDate")]
        public DateTime JoinDate { get; set; }

        [Column("Phone")]
        [StringLength(8)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "please insert int")]
        [Column("CustomerNo")]
        public int CustomerNo { get; set; } = 1;

        [ForeignKey("CustomerRefId")]
        public ICollection<Movie> Movies { get; set; }

    }



}