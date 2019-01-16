using Microsoft.EntityFrameworkCore;

namespace ModelCore.Data
{
    public class AppContext : DbContext
    {
        #region Construct

        public AppContext(DbContextOptions<AppContext> options):base(options)
        {}

        #endregion

        #region DbSet's

        public DbSet<> MyProperty { get; set; }

        #endregion
    }
}
