using Exam.DAL.Entities;

namespace Exam.UI.ViewModels.Objs
{
    public class UserViewModel
    {
        public string Name { get; set; }

        public UserViewModel()
        {
            
        }

        public UserViewModel(UserEntity dbObj)
        {
            if (dbObj != null)
            {
                Name = dbObj.Name;
            }
        }
    }
}