using Exam.DAL.Entities;

namespace Exam.UI.Infrastructure.Services
{
    public interface IAuthService
    {
        bool ValidateUser(string userName, string password);

        string GeneratePasswordSalt();

        string CreatePasswordHash(string password, string passwordSalt);

        UserEntity GetUser(string userName);

        UserEntity CreateUser(string userName, string passwordHash, string passwordSalt);
    }
}
