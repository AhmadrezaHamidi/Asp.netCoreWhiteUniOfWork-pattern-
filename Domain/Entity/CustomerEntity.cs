using System;
using TamsaApi.Domain.BaseDomain;

namespace TamsaApi.Domain.Entity
{
    public class CustomerEntity : BaseDomainEntity
    {
        public CustomerEntity()
        {
        }

        public CustomerEntity(string userName, string email, string phoneNumber, string password)
        {
            Id = Guid.NewGuid().ToString();
            IsDeleted = false;
            CreateAt = DateTime.Now;
            UserName = userName;
            Email = email;
            PhoneNumber = phoneNumber;
            LastTransActionId = null;
            Password = password;
        }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string LastTransActionId { get; set; }
        public string Password { get; set; }
    }
}