using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Exam.DAL.Contracts;

namespace Exam.EF
{
    public class EFDbContext : DbContext
    {
        public new IDbSet<TEntity> Set<TEntity>() 
            where TEntity : Entity
        {
            return base.Set<TEntity>();
        }

        public EFDbContext(string connectionString, bool showSql)
        {
            if (showSql)
            {
                Database.Log = sql => Debug.Write(sql);
            }

            Database.Connection.ConnectionString = connectionString;

            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !String.IsNullOrEmpty(type.Namespace))
                .Where(type => type.BaseType != null && type.BaseType.IsGenericType
                               && type.BaseType.GetGenericTypeDefinition() == typeof(EntityMap<>));

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
