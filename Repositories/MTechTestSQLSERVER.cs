using Microsoft.EntityFrameworkCore;

namespace MTechTestAPI.Repositories
{
    public class MTechTestSQLSERVER : MTechTestIMDb
    {
        public MTechTestSQLSERVER(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=mtechtest;Uid=sa;Pwd=123;");
            }
        }
    }
}
