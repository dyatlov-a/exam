using System;

namespace Exam.DAL.Contracts
{
    public interface IEntity
    {
        Guid Id { get; set; }

        string DisplayName { get; }

        bool IsSave { get; set; }
    }
}
