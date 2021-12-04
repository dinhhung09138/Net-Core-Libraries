using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sql.Database
{
    public sealed class ContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            const string connectionString = "Data Source=DESKTOP-SLG90SD\\SQLEXPRESS;Initial Catalog=DemoMigrationDB_Net6;User Id=sa;Password=123456;";
            return new Context(new DbContextOptionsBuilder<Context>().UseSqlServer(connectionString).Options);
        }
    }
}
