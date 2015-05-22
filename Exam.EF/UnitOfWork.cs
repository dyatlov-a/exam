using System.Data.Entity;
using Exam.DAL;

namespace Exam.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }
    }
}
