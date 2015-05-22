using System;
using System.Collections.Generic;
using Exam.DAL.Contracts;

namespace Exam.DAL.Entities
{
    public class UserEntity : Entity
    {      
        public string Name { get; set; }

        public string Password { get; set; }

        public string PasswordSalt { get; set; }

        public ICollection<ActiveEntity> ActiveList { get; set; }

        public override string DisplayName
        {
            get { return Name; }
        }

        public UserEntity()
        {
            Id = Guid.NewGuid();
            ActiveList = new List<ActiveEntity>();
        }
    }
}
