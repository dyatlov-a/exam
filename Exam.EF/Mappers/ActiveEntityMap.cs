using Exam.DAL.Entities;

namespace Exam.EF.Mappers
{
    public class ActiveEntityMap : EntityMap<ActiveEntity>
    {
        public ActiveEntityMap()
            : base("Active", "act")
        {
            Property(x => x.Topic)
                .HasColumnName("act_Topic");
            Property(x => x.Text)
                .HasColumnName("act_Text");
        }
    }
}
