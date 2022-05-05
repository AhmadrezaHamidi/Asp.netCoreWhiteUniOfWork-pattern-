using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PocketBook.Core.IConfiguration;
using TamsaApi.Core.IRepositories;
using TamsaApi.Core.Repositories;
using tTamsaApi.Domain.BaseDomain;

namespace TamsaApi.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly TamsaApisaContext _dbContext;
        protected readonly ILogger _logger;
        public IUserRepository Users { get;private set; }

        public UnitOfWork(TamsaApisaContext dbContext, ILoggerFactory loggerFactory)
        {
            _dbContext = dbContext;
            _logger = loggerFactory.CreateLogger(nameof(UnitOfWork));
            Users = new UserRepository(_dbContext,loggerFactory.CreateLogger(nameof(UserRepository)));
        }





        public async Task CompleteAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
             _dbContext.DisposeAsync();
        }
        // public async Task Dispose()
        // {
        //     await _dbContext.DisposeAsync();
        // }
    }
}