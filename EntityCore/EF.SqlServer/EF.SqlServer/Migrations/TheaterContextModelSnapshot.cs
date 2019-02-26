﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using TestDb.Models;

namespace EF.SqlServer.Migrations
{
    [DbContext(typeof(TheaterContext))]
    partial class TheaterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestDb.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("JoinDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Phone");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("TestDb.Models.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("MovieId1");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("MovieId");

                    b.HasIndex("MovieId1");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("TestDb.Models.Movie", b =>
                {
                    b.HasOne("TestDb.Models.Movie")
                        .WithMany("Movies")
                        .HasForeignKey("MovieId1");
                });
#pragma warning restore 612, 618
        }
    }
}