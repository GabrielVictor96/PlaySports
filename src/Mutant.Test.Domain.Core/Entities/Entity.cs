using System;

namespace PlaySports.Domain.Core.Entities
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; protected set; }

        public void FillId(Guid id) => Id = id; 
    }
}