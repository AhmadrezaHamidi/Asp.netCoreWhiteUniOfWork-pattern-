using System.Collections.Generic;
using System.Threading.Tasks;
using TamsaApi.Domain.BaseDomain;
using TamsaApi.Domain.Entity;

namespace TamsaApi.Core.IRepositories
{
    public interface IGenericRepositories<T> where T : BaseDomainEntity
    {
         Task<IEnumerable<T>> All();
         Task<T> GetById(string id);
         Task<bool> Add(T entity);
         Task<bool> Delete(string id);
         Task<bool> Upsert(T entity);
    }
    public interface IUserRepository : IGenericRepositories<CustomerEntity>{
          bool isExistByEmail(string emailAddress);
          bool isExistByPhoneNumber(string phoneNumber);
         public CustomerEntity LogingWhiteEmail(string emailAddress,string password);
    }    
    
}