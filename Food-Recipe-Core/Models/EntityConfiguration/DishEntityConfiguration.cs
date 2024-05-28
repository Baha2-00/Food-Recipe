using Food_Recipe_Core.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Core.Models.EntityConfiguration
{
    public class DishEntityConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CreationDate).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Image).IsRequired(false);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);

            //Relationships 
            builder.HasMany<DishIngredient>().WithOne().HasForeignKey(x => x.DishId);
            builder.HasMany<DishPreparingSteps>().WithOne().HasForeignKey(x => x.DishId);
        }
    }
}
