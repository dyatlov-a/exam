﻿using Exam.DAL.Entities;

namespace Exam.EF.Mappers
{
    /// <summary>
    /// Проекция на БД типа - пользователь
    /// </summary>
    public class UserEntityMap : EntityMap<UserEntity>
    {
        public UserEntityMap()
            : base("User", "usr")
        {
            Property(x => x.Name)
                .HasColumnName("usr_Name");
            Property(x => x.Password)
                .HasColumnName("usr_Password");
            Property(x => x.PasswordSalt)
                .HasColumnName("usr_PasswordSalt");
        }
    }
}
