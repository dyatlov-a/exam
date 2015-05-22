using System;

namespace Exam.DAL.Contracts
{
    /// <summary>
    /// Базовый тип сущности, для работы с БД
    /// </summary>
    public abstract class Entity
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
