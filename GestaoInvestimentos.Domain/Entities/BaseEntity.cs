using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestaoInvestimentos.Domain.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
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
