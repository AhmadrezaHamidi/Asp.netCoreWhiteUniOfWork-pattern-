using System;
using TamsaApi.Domain.BaseDomain;

namespace TamsaApi.Domain.Entity
{
    public class BackUpEntity : BaseDomainEntity
    {
       
        public string usereId { get; set; }
        public byte[] File { get; set; }

        public BackUpEntity(string usereId, byte[] fieldA)
        {
            Id = Guid.NewGuid().ToString();
            IsDeleted = false;
            CreateAt = DateTime.Now;
            this.usereId = usereId;
            File = fieldA;
        }
    }
}