using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Domain.Entities
{
    public class BaseEntityUpdatable : BaseEntity
    {
        protected BaseEntityUpdatable():base()
        {
           
            UpdatedAt = DateTime.UtcNow;
        }
        protected BaseEntityUpdatable(int id) : base(id)
        {
            UpdatedAt = DateTime.UtcNow;
        }
        protected BaseEntityUpdatable(int id, DateTime createdAt, DateTime updatedAt) : base(id,createdAt)
        {
            UpdatedAt = updatedAt;
        }
        public void SetUpdatedAt()
        {
            UpdatedAt = DateTime.UtcNow;
        }
        public virtual DateTime UpdatedAt { get; set; }
    }
}
