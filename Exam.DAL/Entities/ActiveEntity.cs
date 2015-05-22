using System;
using Exam.DAL.Contracts;

namespace Exam.DAL.Entities
{
    public class ActiveEntity : Entity
    {
        public string Topic { get; set; }

        public string Text { get; set; }

        public Guid UserId { get; set; }
        public UserEntity User { get; set; }

        public override string DisplayName
        {
            get { return Topic; }
        }

        public ActiveEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}
