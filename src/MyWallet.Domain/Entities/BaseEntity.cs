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
            UpdatedAt = DateTime.UtcNow;
        }
        protected BaseEntity(int id)
        {
            Id = id;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
        protected BaseEntity(int id, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
        public void SetUpdatedAt()
        {
            UpdatedAt = DateTime.UtcNow;
        }

        public int Id { get; set; }
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; set; }
    }
}
