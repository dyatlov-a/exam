using System;
using Exam.DAL.Entities;

namespace Exam.UI.ViewModels.Objs
{
    public class TaskViewModel
    {
        public Guid Id { get; set; }

        public string Topic { get; set; }

        public string Text { get; set; }

        public TaskViewModel()
        {
        }

        public TaskViewModel(TaskEntity dbObj)
        {
            if (dbObj != null)
            {
                Id = dbObj.Id;
                Topic = dbObj.Topic;
                Text = dbObj.Text;
            }
        }
    }
}