using System.Configuration;
using System.Data.Entity;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Exam.DAL;
using Exam.EF;
using Exam.UI.Infrastructure.Services;
using Exam.UI.Infrastructure.Services.Default;

namespace Exam.UI.Infrastructure
{
    public static class IoC
    {
        public static void Init()
        {
            var builder = ServicesRegiser(new ContainerBuilder());

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static ContainerBuilder ServicesRegiser(ContainerBuilder builder)
        {
            builder.RegisterType<EFDbContext>().As<DbContext>()
                .InstancePerLifetimeScope()
                .WithParameter("connectionString",
                    ConfigurationManager.ConnectionStrings["defaultConnectionString"].ConnectionString)
                .WithParameter("showSql", false);
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>()
                .InstancePerLifetimeScope();
            builder.RegisterType<Repository>().As<IRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<DefaultToDoService>().As<IToDoService>()
                .InstancePerLifetimeScope();

            return builder;
        }
    }
}