using Microsoft.EntityFrameworkCore;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sql.Database
{
    public static class ContextSeed
    {
        public static void Seed(this ModelBuilder builder)
        {
            SeedEmployees(builder);
        }

        private static void SeedEmployees(this ModelBuilder builder)
        {
            builder.Entity<Domain.Employee>(m =>
            {
                m.HasData(new {
                    Id = 1L,
                    Name = "Hung Tran",
                    Age = 10,
                    Phone = "0989.898.223",
                    Email = "abc@gmail.com",
                });
            });
        }
    }
}
