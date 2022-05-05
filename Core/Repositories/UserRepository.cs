using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PocketBook.Core.Repositories;
using TamsaApi.Core.IRepositories;
using TamsaApi.Domain.Entity;
using tTamsaApi.Domain.BaseDomain;

namespace TamsaApi.Core.Repositories
{
    public class UserRepository : GenericRepository<CustomerEntity>, IUserRepository
    {

        public UserRepository(TamsaApisaContext context, ILogger logger) : base(context, logger)
        {
        }
         public override async Task<IEnumerable<CustomerEntity>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error", typeof(UserRepository));
                return new List<CustomerEntity>();
            }
        }

        public override async Task<bool> Upsert(CustomerEntity entity)
        {
            try
            {
                var existingUser = await dbSet.Where(x => x.Id == entity.Id)
                                                        .FirstOrDefaultAsync();

                if(existingUser == null)
                    return await Add(entity);

                existingUser.UserName = entity.UserName;
                existingUser.PhoneNumber = entity.PhoneNumber;
                existingUser.Email = entity.Email;

                return true;
            }
            catch(Exception ex)
            {
                 _logger.LogError(ex, "{Repo} Upsert method error", typeof(UserRepository));
                return false;
            }
        }

        public override async Task<bool> Delete(string id)
        {
            try
            {
                var exist = await dbSet.Where(x => x.Id == id)
                                    .FirstOrDefaultAsync();

                if(exist != null)
                {
                    exist.IsDeleted = true;
                    return true;
                }

                return false;     
            }
            catch(Exception ex)
            {
                 _logger.LogError(ex, "{Repo} Delete method error", typeof(UserRepository));
                return false;
            }
        }
        public bool isExistByEmail(string emailAddress)
        {
            return dbSet.Any(x => x.Email.Equals(emailAddress));
        }

        public bool isExistByPhoneNumber(string phoneNumber)
        {
            return dbSet.Any(x => x.Email.Equals(phoneNumber));
        }

        
        public CustomerEntity LogingWhiteEmail(string emailAddress,string password)
        {
            return dbSet.SingleOrDefault(x => x.Email.Equals(emailAddress) &&
             x.Password.Equals(password));
        }
    }
}