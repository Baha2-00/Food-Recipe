﻿using Food_Recipe_Core.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Core.Models.EntityConfiguration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CreationDate).IsRequired();
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Phone).IsRequired();
            builder.Property(x => x.BirthDate).IsRequired();
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);

            //RelationShips
            builder.HasMany<Dish>().WithOne().HasForeignKey(x => x.UserId);
            builder.HasMany<DishRequest>().WithOne().HasForeignKey(x => x.UserId);
            builder.HasMany<UserSubscription>().WithOne().HasForeignKey(x => x.UserId);
            builder.HasOne<Login>().WithOne().HasForeignKey<Login>(x => x.UserId);
        }
    }
}
