using System.Collections.Generic;
using Exam.DAL.Contracts;

namespace Exam.DAL.Entities
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class UserEntity : Entity
    {      
        public string Name { get; set; }

        public string Password { get; set; }

        public string PasswordSalt { get; set; }

        public virtual ICollection<TaskEntity> ActiveList { get; set; }

        public override string DisplayName
        {
            get { return Name; }
        }

        public UserEntity()
        {
            ActiveList = new List<TaskEntity>();
        }
    }
}
