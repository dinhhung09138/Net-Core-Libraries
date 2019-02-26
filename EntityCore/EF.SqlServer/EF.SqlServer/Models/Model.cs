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

        //Create DBSet for Entity
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }

    public class Movie
    {
        //ID and Column for DB
        [Key]
        [Column("MovieId")]
        public int MovieId { get; set; }

        //Not null field with error message
        [Required(ErrorMessage = "Movie need name.")]
        [Column("Title")]
        public string Title { get; set; }

        //Reference key from Customer
        [Column("CustomerRefId")]
        public int CustomerRefId { get; set; }

        //FK customer
        public Customer Customer { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }

    public class Customer
    {
        [Key]
        [Column("CustomerId")]
        public int CustomerId { get; set; }

        //Datatype and error message
        [Required(ErrorMessage = "Customer need name.")]
        [DataType(DataType.Text)]
        [Column("Name")]
        public string Name { get; set; }

        //Datatype with Display format
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString ="{0: dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        [Column("JoinDate")]
        public DateTime JoinDate { get; set; }

        //Length for column
        [Column("Phone")]
        [StringLength(8)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        //Int with Range and error message
        [Range(0, int.MaxValue, ErrorMessage = "please insert int")]
        [Column("CustomerNo")]
        public int CustomerNo { get; set; } = 1;

        [ForeignKey("CustomerRefId")]
        public ICollection<Movie> Movies { get; set; }

    }



}