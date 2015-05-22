using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Exam.DAL;
using Exam.DAL.Entities;

namespace Exam.UI.Infrastructure.Services.Default
{
    public class DefaultAuthService : IAuthService
    {
        private readonly IRepository _repository;

        public DefaultAuthService(IRepository repository)
        {
            _repository = repository;
        }

        private static byte[] HexToByte(string hexString)
        {
            var bytes = new byte[hexString.Length * sizeof(char)];
            Buffer.BlockCopy(hexString.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        private static string GeneratePassword(int x)
        {
            string pass = "";
            var r = new Random();
            while (pass.Length < x)
            {
                Char c = (char)r.Next(33, 125);
                if (Char.IsLetterOrDigit(c))
                    pass += c;
            }
            return pass;
        }

        public bool ValidateUser(string userName, string password)
        {
            var user = _repository.Get<UserEntity>()
                .FirstOrDefault(d => d.Name == userName);

            return (user != null) && (user.Password == CreatePasswordHash(password, user.PasswordSalt));
        }

        public string GeneratePasswordSalt()
        {
            try
            {
                var rng = new RNGCryptoServiceProvider();
                var buff = new byte[8];
                rng.GetBytes(buff);
                return Convert.ToBase64String(buff);
            }
            catch (Exception ex)
            {
                throw new SystemException("Failed generate password salt", ex);
            }
        }

        public string CreatePasswordHash(string password, string passwordSaltBase64)
        {
            try
            {
                var hash = new HMACSHA1 { Key = HexToByte(passwordSaltBase64) };
                var encodedPassword = Convert.ToBase64String(hash.ComputeHash(Encoding.Unicode.GetBytes(password)));
                return encodedPassword;
            }
            catch (Exception ex)
            {
                throw new SystemException("Failed to create password hash.", ex);
            }
        }

        public UserEntity GetUser(string userName)
        {
            return _repository.Get<UserEntity>()
                .FirstOrDefault(d => d.Name == userName);
        }

        public UserEntity CreateUser(string userName, string passwordHash, string passwordSalt)
        {
            var user = new UserEntity
            {
                Name = userName,
                Password = passwordHash,
                PasswordSalt = passwordSalt,
            };
            _repository.InsertOrUpdate<UserEntity>(user);

            return user;
        }
    }
}