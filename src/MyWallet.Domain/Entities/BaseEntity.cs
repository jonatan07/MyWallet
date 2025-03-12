using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Domain.Entities
{
    public class BaseEntity
    {
        protected BaseEntity()
        {
            CreatedAt = DateTime.UtcNow;
           
        }
        protected BaseEntity(int id)
        {
            Id = id;
            CreatedAt = DateTime.UtcNow;
        }
        protected BaseEntity(int id, DateTime createdAt)
        {
            Id = id;
            CreatedAt = createdAt;
        }
        public int Id { get; set; }
        public DateTime CreatedAt { get; init; }
    }
}
