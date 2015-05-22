using Exam.DAL.Entities;

namespace Exam.UI.ViewModels.Objs
{
    public class ActiveViewModel
    {
        public string Topic { get; set; }

        public string Text { get; set; }

        public ActiveViewModel()
        {
        }

        public ActiveViewModel(ActiveEntity dbObj)
        {
            if (dbObj != null)
            {
                Topic = dbObj.Topic;
                Text = dbObj.Text;
            }
        }
    }
}