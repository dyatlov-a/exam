using System.Data.Entity.ModelConfiguration;
using Exam.DAL.Contracts;

namespace Exam.EF
{
    public class EntityMap<TEntity> : EntityTypeConfiguration<TEntity>
        where TEntity : Entity
    {
        /// <summary>
        /// Базовый мапер
        /// </summary>
        /// <param name="tableName">Название таблицы в БД</param>
        /// <param name="prefix">Префикс полей в БД</param>
        public EntityMap(string tableName, string prefix)
        {
            ToTable(tableName);
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName(string.Format("{0}_Id", prefix));
            Property(x => x.Created)
                .HasColumnName(string.Format("{0}_Created", prefix));
            Property(x => x.Modified)
                .HasColumnName(string.Format("{0}_Modified", prefix));
            Property(x => x.IsSave)
                .HasColumnName(string.Format("{0}_IsSave", prefix));
        }
    }
}
