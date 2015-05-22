using Exam.DAL.Entities;

namespace Exam.UI.Infrastructure.Services
{
    public interface IAuthService
    {
        /// <summary>
        /// Проверка пользователя
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <param name="password">Пароль</param>
        /// <returns>Успешность проверки</returns>
        bool ValidateUser(string userName, string password);

        /// <summary>
        /// Генерация соли для пароля
        /// </summary>
        /// <returns>Соль</returns>
        string GeneratePasswordSalt();

        /// <summary>
        /// Хеширование пароля
        /// </summary>
        /// <param name="password">Пароль</param>
        /// <param name="passwordSalt">Соль</param>
        /// <returns>Захешированный пароль</returns>
        string CreatePasswordHash(string password, string passwordSalt);

        /// <summary>
        /// Получить пользователя по имени
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <returns>Сущность пользователя</returns>
        UserEntity GetUser(string userName);

        /// <summary>
        /// Создать пользователя
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <param name="passwordHash">Захешированный пароль</param>
        /// <param name="passwordSalt">Соль</param>
        /// <returns>Сущность пользователя</returns>
        UserEntity CreateUser(string userName, string passwordHash, string passwordSalt);
    }
}
