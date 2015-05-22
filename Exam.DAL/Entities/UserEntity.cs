using System;
using Exam.DAL.Contracts;

namespace Exam.DAL.Entities
{
    public class UserEntity : Entity
    {      
        public string Name { get; set; }

        public override string DisplayName
        {
            get { return Name; }
        }

        public UserEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}
