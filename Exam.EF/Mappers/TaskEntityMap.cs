using Exam.DAL.Entities;

namespace Exam.EF.Mappers
{
    /// <summary>
    /// Проекция на БД типа - задача
    /// </summary>
    public class TaskEntityMap : EntityMap<TaskEntity>
    {
        public TaskEntityMap()
            : base("Task", "tsk")
        {
            Property(x => x.Topic)
                .HasColumnName("tsk_Topic");
            Property(x => x.Text)
                .HasColumnName("tsk_Text");
            Property(x => x.UserId)
                .HasColumnName("tsk_UserId");
            Property(x => x.Achieved)
                .HasColumnName("tsk_Achieved");

            HasOptional(x => x.User)
                .WithMany(y => y.ActiveList)
                .HasForeignKey(k => k.UserId);
        }
    }
}
