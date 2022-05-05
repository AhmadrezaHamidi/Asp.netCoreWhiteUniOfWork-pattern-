using System;

namespace TamsaApi.Domain.BaseDomain
{
    public abstract class BaseDomainEntity
    {
        public string Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateAt { get; set; }
    } 
}