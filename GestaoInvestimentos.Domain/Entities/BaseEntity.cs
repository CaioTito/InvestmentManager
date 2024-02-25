using System;

namespace GestaoInvestimentos.Domain.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; private set; }

        public void Delete()
        {
            UpdatedAt = DateTime.Now;
            DeletedAt = DateTime.Now;
        }
    }
}
