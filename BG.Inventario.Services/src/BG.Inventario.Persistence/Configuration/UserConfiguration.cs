using BG.Inventario.Domain.Entities.User;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BG.Inventario.Persistence.Configuration
{
    public class UserConfiguration
    {
        public UserConfiguration(EntityTypeBuilder<UserEntity> entityBuilder)
        {
            entityBuilder.HasKey(e => e.UserId);
            entityBuilder.Property(e => e.FirstName).IsRequired();
            entityBuilder.Property(e => e.LastName).IsRequired();
            entityBuilder.Property(e => e.UserName).IsRequired();
            entityBuilder.Property(e => e.Password).IsRequired();
        }
    }
}
