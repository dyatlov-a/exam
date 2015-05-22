using System;

namespace Exam.DAL.Contracts
{
    public abstract class Entity : IEntity
    {
        public Guid Id { get; set; }

        public virtual string DisplayName
        {
            get
            {
                return Id.ToString();
            }
        }

        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }

        public bool IsSave { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
