using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Sql.Database
{
    public sealed class ContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            const string connectString = "Data Source=DESKTOP-SLG90SD\\SQLEXPRESS;Initial Catalog=DemoMigrationDB;User Id=sa;Password=123456;";

            return new Context(new DbContextOptionsBuilder<Context>().UseSqlServer(connectString).Options);
        }
    }
}
