using System;
using Exam.DAL.Contracts;

namespace Exam.DAL.Entities
{
    public class TaskEntity : Entity
    {
        public string Topic { get; set; }

        public string Text { get; set; }

        public bool Achieved { get; set; }

        public Guid? UserId { get; set; }
        public virtual UserEntity User { get; set; }

        public override string DisplayName
        {
            get { return Topic; }
        }
    }
}
