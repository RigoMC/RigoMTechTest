using Microsoft.EntityFrameworkCore;

namespace MTechTestAPI.Repositories
{
    public class MTechTestMYSQL : MTechTestIMDb
    {
        public MTechTestMYSQL(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseMySql("Server=127.0.0.1;Database=mtechtest;Uid=root;Pwd=;",
                   new MariaDbServerVersion(new Version(10, 3, 29)));
            }
        }
    }
}
