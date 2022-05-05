using Microsoft.EntityFrameworkCore;
using TamsaApi.Domain.Entity;

namespace tTamsaApi.Domain.BaseDomain
{
    public class TamsaApisaContext : DbContext
    {
        public TamsaApisaContext(DbContextOptions options) : base(options)
        {
        }
      //  public DbSet<BackUpEntity> BackUpTb { get; set; }
        public DbSet<CustomerEntity> CustomerTb { get; set; }
        public DbSet<TransActionEntity> TransActionTb { get; set; }
    }
}